using KollexionSuite.Application.Common.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using KollexionSuite.Infrastructure.Data;
using System.Linq.Expressions;

namespace KollexionSuite.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }
        public async Task<T?> GetByIdAsync(string id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbSet.ToListAsync(ct);
        }

        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbSet.Where(predicate).ToListAsync(ct);
        }

        public async Task<T?> GetMaxAsync<TKey>(Expression<Func<T, TKey>> orderBySelector, Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null) query = query.Where(predicate);

            return await query.OrderByDescending(orderBySelector).FirstOrDefaultAsync(ct);
        }

        public async Task AddAsync(T entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity, ct);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
        {
            await _dbSet.AddRangeAsync(entities, ct);
        }

        public Task UpdateAsync(T entity, CancellationToken ct = default)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, ct);
            if (entity is not null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _context.SaveChangesAsync(ct);
        }
        public async Task<IEnumerable<T>> GetAllIncludingAsync(CancellationToken ct = default, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<T>> FindByIncludingAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? include = null, CancellationToken ct = default)
        {
            IQueryable<T> query = _dbSet;

            if (include is not null)
                query = include(query);

            return await query.Where(predicate).ToListAsync(ct);
        }

        public async Task<T?> GetByIdIncludingAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default, Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query = _dbSet;

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(predicate, ct);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbSet.AnyAsync(predicate, ct);
        }
    }
}
