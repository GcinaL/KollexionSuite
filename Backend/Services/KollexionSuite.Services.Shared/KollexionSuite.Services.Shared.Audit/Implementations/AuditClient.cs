using KollexionSuite.Services.Shared.Audit.Abstractions;
using KollexionSuite.Services.Shared.Audit.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace KollexionSuite.Services.Shared.Audit.Implementations
{
    public class AuditClient : IAuditClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AuditClient> _logger;
        private readonly AuditServiceSettings _settings;

        public AuditClient(HttpClient httpClient,IOptions<AuditServiceSettings> settings,ILogger<AuditClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _settings = settings.Value;
        }

        public async Task AddAsync(CreateAuditDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_settings.BaseUrl, dto, cancellationToken);
                response.EnsureSuccessStatusCode();

                _logger.LogInformation("Audit logged: {Entity} ({Id}) by {Actor}", dto.EntityName, dto.EntityId, dto.Actor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to log audit for {Entity} ({Id})", dto.EntityName, dto.EntityId);
                throw;
            }
        }
    }
}
