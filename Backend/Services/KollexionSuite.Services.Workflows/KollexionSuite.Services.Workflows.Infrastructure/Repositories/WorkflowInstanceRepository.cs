using KollexionSuite.Services.Workflows.Domain.Entities;
using KollexionSuite.Services.Workflows.Domain.IRepository;
using KollexionSuite.Services.Workflows.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.Workflows.Infrastructure.Repositories
{
    public sealed class WorkflowInstanceRepository : WorkflowRepository<WorkflowInstance>, IWorkflowInstanceRepository
    {
        public WorkflowInstanceRepository(WorkflowDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<WorkflowInstance?> GetActiveByIdAsync(Guid instanceId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.WorkflowInstances
                .Include(i => i.WorkflowDefinition)
                    .ThenInclude(d => d.Steps)
                .Include(i => i.Steps)
                .FirstOrDefaultAsync(i => i.Id == instanceId, cancellationToken);
        }
    }
}
