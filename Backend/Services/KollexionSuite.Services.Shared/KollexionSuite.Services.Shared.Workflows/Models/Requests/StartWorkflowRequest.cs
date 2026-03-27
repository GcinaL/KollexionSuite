namespace KollexionSuite.Services.Shared.Workflows.Models.Requests
{
    public sealed class StartWorkflowRequest
    {
        public string WorkflowName { get; set; } = default!;
        public string CorrelationId { get; set; } = default!; // e.g. CaseId, DebtorId
        public string? InitialPayloadJson { get; set; }
    }
}
