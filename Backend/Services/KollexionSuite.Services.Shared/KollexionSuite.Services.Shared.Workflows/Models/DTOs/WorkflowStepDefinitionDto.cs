namespace KollexionSuite.Services.Shared.Workflows.Models.DTOs
{
    public sealed class WorkflowStepDefinitionDto
    {
        public int Order { get; set; }
        public string StepName { get; set; } = default!;
        public string RequestTopic { get; set; } = default!;
        public string ResultTopic { get; set; } = default!;
        public string? CompensationTopic { get; set; }
        public int TimeoutSeconds { get; set; } = 60;
    }
}
