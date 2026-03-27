using KollexionSuite.Services.Debtors.Domain.Entities;

namespace KollexionSuite.Services.Debtors.Domain.IRepositories
{
    public interface IDebtorRepository
    {
        Task<Debtor?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Debtor?> GetByIdentifierAsync(string type, string value, CancellationToken cancellationToken);
        Task<IEnumerable<Debtor>> GetAllAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 50);
        Task AddAsync(Debtor debtor, CancellationToken cancellationToken);
        Task UpdateAsync(Debtor debtor, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
