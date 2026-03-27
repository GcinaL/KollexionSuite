using KollexionSuite.Services.Shared.Workflows.Models.DTOs;

namespace KollexionSuite.Services.Shared.Workflows.Models.Requests
{
    public sealed class RegisterWorkflowDefinitionRequest
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<WorkflowStepDefinitionDto> Steps { get; set; } = new();
    }
}
