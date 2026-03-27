using KollexionSuite.Services.MessageBroker.Application.Contracts.Events;

namespace KollexionSuite.Services.MessageBroker.Application.Interfaces
{
    public interface IWorkflowOrchestrationClient
    {
        Task SendWorkflowStepResultAsync(WorkflowStepResultEvent evt, CancellationToken cancellationToken = default);
    }
}
