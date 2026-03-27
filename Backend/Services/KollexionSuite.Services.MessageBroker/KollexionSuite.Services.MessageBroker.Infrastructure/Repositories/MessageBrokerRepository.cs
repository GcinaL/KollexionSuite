using KollexionSuite.Services.MessageBroker.Domain.Common;
using KollexionSuite.Services.MessageBroker.Domain.IRepositories;
using KollexionSuite.Services.MessageBroker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.Repositories
{
    public class MessageBrokerRepository<T> : IMessageBrokerRepository<T> where T : BaseEntity
    {
        protected readonly MessageBrokerDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public MessageBrokerRepository(MessageBrokerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>>? predicate = null,int? take = null,CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet;
            if (predicate is not null)
                query = query.Where(predicate);

            if (take.HasValue)
                query = query.Take(take.Value);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _dbSet.AddAsync(entity, cancellationToken);

        public void Update(T entity)
            => _dbSet.Update(entity);
    }
}
