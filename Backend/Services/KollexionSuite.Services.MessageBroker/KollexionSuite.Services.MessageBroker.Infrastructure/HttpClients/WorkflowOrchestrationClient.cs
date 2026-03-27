using KollexionSuite.Services.MessageBroker.Application.Contracts.Events;
using KollexionSuite.Services.MessageBroker.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.HttpClients
{
    public sealed class WorkflowOrchestrationClient : IWorkflowOrchestrationClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WorkflowOrchestrationClient> _logger;
        private readonly string _callbackUrl;

        public WorkflowOrchestrationClient(HttpClient httpClient,IConfiguration config,ILogger<WorkflowOrchestrationClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            // e.g. "http://workflow-orchestration/api/workflows/results"
            _callbackUrl = config["WorkflowOrchestration:CallbackUrl"] ?? throw new InvalidOperationException("WorkflowOrchestration:CallbackUrl not configured");
        }

        public async Task SendWorkflowStepResultAsync(
            WorkflowStepResultEvent evt,
            CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync(_callbackUrl, evt, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync(cancellationToken);
                _logger.LogError("Failed to callback WorkflowOrchestration. Status: {Status}, Body: {Body}",
                    response.StatusCode, body);
                response.EnsureSuccessStatusCode();
            }

            _logger.LogInformation("Sent WorkflowStepResultEvent to WorkflowOrchestration for instance {InstanceId}", evt.WorkflowInstanceId);
        }
    }
}
