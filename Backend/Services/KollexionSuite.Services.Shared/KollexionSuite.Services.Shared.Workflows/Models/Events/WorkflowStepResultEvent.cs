namespace KollexionSuite.Services.Shared.Workflows.Models.Events
{
    public sealed class WorkflowStepResultEvent
    {
        public Guid WorkflowInstanceId { get; set; }
        public Guid StepInstanceId { get; set; }
        public string StepName { get; set; } = default!;
        public string CorrelationId { get; set; } = default!;
        public bool Success { get; set; } = true;
        public string? ResultPayloadJson { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
