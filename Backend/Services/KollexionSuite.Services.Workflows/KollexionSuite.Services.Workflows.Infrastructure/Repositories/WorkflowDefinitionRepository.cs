using KollexionSuite.Services.Workflows.Domain.Entities;
using KollexionSuite.Services.Workflows.Domain.IRepository;
using KollexionSuite.Services.Workflows.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.Workflows.Infrastructure.Repositories
{
    public sealed class WorkflowDefinitionRepository : WorkflowRepository<WorkflowDefinition>, IWorkflowDefinitionRepository
    {
        public WorkflowDefinitionRepository(WorkflowDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<WorkflowDefinition?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _dbContext.WorkflowDefinitions
                .Include(w => w.Steps)
                .FirstOrDefaultAsync(w => w.Name == name, cancellationToken);
        }
    }
}
