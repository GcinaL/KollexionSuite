using KollexionSuite.Services.Workflows.Domain.Common;
using KollexionSuite.Services.Workflows.Domain.IRepository;
using KollexionSuite.Services.Workflows.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KollexionSuite.Services.Workflows.Infrastructure.Repositories
{
    public class WorkflowRepository<T> : IWorkflowRepository<T> where T : BaseEntity
    {
        protected readonly WorkflowDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public WorkflowRepository(WorkflowDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>>? predicate = null,CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet;

            if (predicate is not null)
                query = query.Where(predicate);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _dbSet.AddAsync(entity, cancellationToken);

        public void Update(T entity)
            => _dbSet.Update(entity);
    }
}
