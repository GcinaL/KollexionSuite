using KollexionSuite.Services.Workflows.Domain.Entities;
namespace KollexionSuite.Services.Workflows.Domain.IRepository
{
    public interface IWorkflowInstanceRepository : IWorkflowRepository<WorkflowInstance>
    {
        Task<WorkflowInstance?> GetActiveByIdAsync(Guid instanceId, CancellationToken cancellationToken = default);
    }
}
