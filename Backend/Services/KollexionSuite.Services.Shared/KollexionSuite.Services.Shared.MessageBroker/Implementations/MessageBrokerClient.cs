using KollexionSuite.Services.Shared.MessageBroker.Abstractions;
using KollexionSuite.Services.Shared.MessageBroker.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace KollexionSuite.Services.Shared.MessageBroker.Implementations
{
    public class MessageBrokerClient : IMessageBrokerClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MessageBrokerClient> _logger;
        private readonly MessageBrokerSettings _settings;

        public MessageBrokerClient(
            HttpClient httpClient,
            IOptions<MessageBrokerSettings> settings,
            ILogger<MessageBrokerClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _settings = settings.Value;
        }

        public async Task PublishAsync(string topic, string key, string messageJson, CancellationToken cancellationToken = default)
        {
            var payload = new
            {
                KafkaTopic = topic,
                Key = key,
                Message = messageJson
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync(_settings.BaseUrl, payload, cancellationToken);
                response.EnsureSuccessStatusCode();

                _logger.LogInformation("Message published to MessageBroker [{Topic}]", topic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to publish message to MessageBroker [{Topic}]", topic);
                throw;
            }
        }
    }
}
