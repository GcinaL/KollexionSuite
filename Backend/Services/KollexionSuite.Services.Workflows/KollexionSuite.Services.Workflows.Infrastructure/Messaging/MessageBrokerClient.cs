using KollexionSuite.Services.Workflows.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;

namespace KollexionSuite.Services.Workflows.Infrastructure.Messaging
{
    public class MessageBrokerClient : IMessageBrokerClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MessageBrokerClient> _logger;
        private readonly string _brokerUrl;

        public MessageBrokerClient(HttpClient httpClient, IConfiguration config, ILogger<MessageBrokerClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _brokerUrl = config["MessageBroker:BaseUrl"] ?? "http://localhost:5555/api/messages";
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
                var response = await _httpClient.PostAsJsonAsync(_brokerUrl, payload, cancellationToken);
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
