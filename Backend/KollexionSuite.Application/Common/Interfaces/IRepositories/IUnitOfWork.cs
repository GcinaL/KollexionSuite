namespace KollexionSuite.Application.Common.Interfaces.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;

        // Transaction Control
        Task BeginTransactionAsync(CancellationToken ct = default);
        Task CommitTransactionAsync(CancellationToken ct = default);
        Task RollbackTransactionAsync(CancellationToken ct = default);

        // Save changes
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
