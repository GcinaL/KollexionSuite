using KollexionSuite.Services.Workflows.Domain.Common;
using System.Linq.Expressions;

namespace KollexionSuite.Services.Workflows.Domain.IRepository
{
    public interface IWorkflowRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
    }
}
