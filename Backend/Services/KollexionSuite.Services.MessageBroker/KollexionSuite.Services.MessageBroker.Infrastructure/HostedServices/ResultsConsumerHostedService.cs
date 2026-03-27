using Confluent.Kafka;
using KollexionSuite.Services.MessageBroker.Domain.Entities;
using KollexionSuite.Services.MessageBroker.Domain.IRepositories;
using KollexionSuite.Services.MessageBroker.Infrastructure.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.HostedServices
{
    public sealed class ResultsConsumerHostedService : BackgroundService
    {
        private readonly ILogger<ResultsConsumerHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly KafkaSettings _kafkaSettings;
        private IConsumer<string?, string>? _consumer;

        public ResultsConsumerHostedService(ILogger<ResultsConsumerHostedService> logger, IServiceProvider serviceProvider, IOptions<KafkaSettings> kafkaOptions)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _kafkaSettings = kafkaOptions.Value;
        }
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _kafkaSettings.BootstrapServers,
                GroupId = "messagebroker-generic-results",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<string?, string>(config).Build();

            using var scope = _serviceProvider.CreateScope();
            var subRepo = scope.ServiceProvider.GetRequiredService<IMessageBrokerRepository<TopicSubscription>>();
            var subscriptions = await subRepo.ListAsync(s => s.IsActive, cancellationToken: cancellationToken);

            if (!subscriptions.Any())
            {
                _logger.LogWarning("No topic subscriptions configured. ResultsConsumerHostedService will idle.");
            }
            else
            {
                var topics = subscriptions.Select(s => s.TopicName).Distinct().ToList();
                _consumer.Subscribe(topics);
                _logger.LogInformation("Subscribed to topics: {Topics}", string.Join(", ", topics));
            }

            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_consumer is null) return;

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var result = _consumer.Consume(stoppingToken);
                    if (result is null) continue;

                    var topic = result.Topic;
                    var payload = result.Message.Value;

                    using var scope = _serviceProvider.CreateScope();
                    var subRepo = scope.ServiceProvider.GetRequiredService<IMessageBrokerRepository<TopicSubscription>>();
                    var subs = await subRepo.ListAsync(s => s.TopicName == topic && s.IsActive, cancellationToken: stoppingToken);

                    if (!subs.Any())
                    {
                        _logger.LogWarning("No active TopicSubscription found for topic {Topic}", topic);
                        continue;
                    }

                    var httpClientFactory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();
                    var client = httpClientFactory.CreateClient("KafkaResultCallbacks");

                    foreach (var sub in subs)
                    {
                        try
                        {
                            var content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");
                            var response = await client.PostAsync(sub.CallbackUrl, content, stoppingToken);

                            if (!response.IsSuccessStatusCode)
                            {
                                var body = await response.Content.ReadAsStringAsync(stoppingToken);
                                _logger.LogError("Callback to {Url} failed. Status: {Status}, Body: {Body}", sub.CallbackUrl, response.StatusCode, body);
                            }
                            else
                            {
                                _logger.LogInformation("Delivered message from topic {Topic} to {Url}", topic, sub.CallbackUrl);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Error delivering message from topic {Topic} to {Url}", topic, sub.CallbackUrl);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // shutting down
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in ResultsConsumerHostedService consumption loop");
                }
            }
        }

        public override void Dispose()
        {
            _consumer?.Close();
            _consumer?.Dispose();
            base.Dispose();
        }
    }
}
