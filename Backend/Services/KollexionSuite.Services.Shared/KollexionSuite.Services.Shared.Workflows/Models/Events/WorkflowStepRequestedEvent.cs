namespace KollexionSuite.Services.Shared.Workflows.Models.Events
{
    public sealed class WorkflowStepRequestedEvent
    {
        public Guid WorkflowInstanceId { get; set; }
        public Guid StepInstanceId { get; set; }
        public string StepName { get; set; } = default!;
        public string CorrelationId { get; set; } = default!;
        public string? PayloadJson { get; set; }
    }
}
