using KollexionSuite.Services.Workflows.Domain.Entities;

namespace KollexionSuite.Services.Workflows.Domain.IRepository
{
    public interface IWorkflowDefinitionRepository : IWorkflowRepository<WorkflowDefinition>
    {
        Task<WorkflowDefinition?> GetByNameAsync(string name,CancellationToken cancellationToken = default);
    }
}
