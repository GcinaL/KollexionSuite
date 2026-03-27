using KollexionSuite.Services.Shared.Workflows.Models.Events;
using KollexionSuite.Services.Shared.Workflows.Models.Requests;
using KollexionSuite.Services.Workflows.Domain.Entities;

namespace KollexionSuite.Services.Workflows.Application.Interfaces
{
    public interface IWorkflowOrchestratorService
    {
        Task<WorkflowDefinition> RegisterWorkflowDefinitionAsync(RegisterWorkflowDefinitionRequest request, CancellationToken cancellationToken = default);

        Task<Guid> StartWorkflowAsync(StartWorkflowRequest request, CancellationToken cancellationToken = default);

        Task HandleStepResultAsync(WorkflowStepResultEvent resultEvent, CancellationToken cancellationToken = default);
    }
}
