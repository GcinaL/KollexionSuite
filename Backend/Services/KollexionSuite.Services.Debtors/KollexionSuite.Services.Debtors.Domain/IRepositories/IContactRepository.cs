using KollexionSuite.Services.Debtors.Domain.Entities;

namespace KollexionSuite.Services.Debtors.Domain.IRepositories
{
    public interface IContactRepository
    {
        Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(Contact contact, CancellationToken cancellationToken);
        Task UpdateAsync(Contact contact, CancellationToken cancellationToken);
    }
}
