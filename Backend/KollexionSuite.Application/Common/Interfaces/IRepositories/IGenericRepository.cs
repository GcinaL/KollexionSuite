using System.Linq.Expressions;

namespace KollexionSuite.Application.Common.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<T?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default);
        Task<IEnumerable<T>> GetAllIncludingAsync(CancellationToken ct = default, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> FindByIncludingAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? include = null, CancellationToken ct = default);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
        Task<T?> GetByIdIncludingAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default, Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task<T?> GetMaxAsync<TKey>(Expression<Func<T, TKey>> orderBySelector, Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default);

        Task AddAsync(T entity, CancellationToken ct = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);
        Task UpdateAsync(T entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
    }
}
