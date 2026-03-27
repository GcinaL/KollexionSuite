using KollexionSuite.Services.MessageBroker.Domain.Common;
using System.Linq.Expressions;

namespace KollexionSuite.Services.MessageBroker.Domain.IRepositories
{
    public interface IMessageBrokerRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> ListAsync(
            Expression<Func<T, bool>>? predicate = null,
            int? take = null,
            CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        void Update(T entity);
    }
}
