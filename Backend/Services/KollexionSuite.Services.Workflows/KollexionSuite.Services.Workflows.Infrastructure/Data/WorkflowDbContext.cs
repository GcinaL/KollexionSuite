using KollexionSuite.Services.Workflows.Domain.Common;
using KollexionSuite.Services.Workflows.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.Workflows.Infrastructure.Data
{
    public sealed class WorkflowDbContext : DbContext, IUnitOfWork
    {
        public WorkflowDbContext(DbContextOptions<WorkflowDbContext> options)
            : base(options)
        {
        }

        public DbSet<WorkflowDefinition> WorkflowDefinitions => Set<WorkflowDefinition>();
        public DbSet<WorkflowStepDefinition> WorkflowStepDefinitions => Set<WorkflowStepDefinition>();
        public DbSet<WorkflowInstance> WorkflowInstances => Set<WorkflowInstance>();
        public DbSet<WorkflowStepInstance> WorkflowStepInstances => Set<WorkflowStepInstance>();

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkflowDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
