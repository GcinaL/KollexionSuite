using Confluent.Kafka;
using KollexionSuite.Services.MessageBroker.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.Messaging
{
    public sealed class KafkaProducer : IKafkaProducer, IDisposable
    {
        private readonly IProducer<string?, string> _producer;
        private readonly ILogger<KafkaProducer> _logger;

        public KafkaProducer(
            IOptions<KafkaSettings> options,
            ILogger<KafkaProducer> logger)
        {
            _logger = logger;
            var config = new ProducerConfig
            {
                BootstrapServers = options.Value.BootstrapServers,
                // TODO: add security config for production
            };

            _producer = new ProducerBuilder<string?, string>(config).Build();
        }

        public async Task ProduceAsync(
            string topic,
            string? key,
            string value,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _producer.ProduceAsync(
                    topic,
                    new Message<string?, string> { Key = key, Value = value },
                    cancellationToken);

                _logger.LogInformation("Published message to Kafka topic {Topic}", topic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error publishing message to Kafka topic {Topic}", topic);
                throw;
            }
        }

        public void Dispose() => _producer.Dispose();
    }
}
