using KollexionSuite.Services.MessageBroker.Application.Interfaces;
using KollexionSuite.Services.MessageBroker.Domain.Common;
using KollexionSuite.Services.MessageBroker.Domain.IRepositories;
using KollexionSuite.Services.MessageBroker.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.HostedServices
{
    public sealed class OutboxPublisherHostedService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<OutboxPublisherHostedService> _logger;
        private const int BatchSize = 100;
        private const int DelayMilliseconds = 2000;
        private const int MaxRetries = 5;

        public OutboxPublisherHostedService(IServiceProvider serviceProvider, ILogger<OutboxPublisherHostedService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("OutboxPublisherHostedService started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var outboxRepo = scope.ServiceProvider.GetRequiredService<IOutboxEventRepository>();
                    var kafkaProducer = scope.ServiceProvider.GetRequiredService<IKafkaProducer>();
                    var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var batch = await outboxRepo.GetPendingBatchAsync(BatchSize, stoppingToken);

                    if (batch.Count == 0)
                    {
                        await Task.Delay(DelayMilliseconds, stoppingToken);
                        continue;
                    }

                    foreach (OutboxEvent evt in batch)
                    {
                        if (stoppingToken.IsCancellationRequested) break;

                        try
                        {
                            evt.MarkInProgress();
                            await uow.SaveChangesAsync(stoppingToken);

                            await kafkaProducer.ProduceAsync(evt.KafkaTopic,evt.Key,evt.PayloadJson,stoppingToken);

                            evt.MarkPublished();
                            await uow.SaveChangesAsync(stoppingToken);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Failed to publish OutboxEvent {EventId}", evt.Id);

                            bool sendToDlq = evt.RetryCount + 1 >= MaxRetries;
                            evt.MarkFailed(ex.Message, sendToDlq);
                            await uow.SaveChangesAsync(stoppingToken);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unhandled error in OutboxPublisherHostedService");
                }

                await Task.Delay(DelayMilliseconds, stoppingToken);
            }

            _logger.LogInformation("OutboxPublisherHostedService stopped.");
        }
    }
}
