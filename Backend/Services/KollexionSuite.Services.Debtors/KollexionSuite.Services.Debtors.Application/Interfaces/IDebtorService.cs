using KollexionSuite.Services.Debtors.Application.DTOs;
using KollexionSuite.Services.Shared.Workflows.Models.Events;

namespace KollexionSuite.Services.Debtors.Application.Interfaces
{
    public interface IDebtorService
    {
        Task<DebtorDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<DebtorDto> GetByIdentifierAsync(string type, string value, CancellationToken cancellationToken);
        Task<IEnumerable<DebtorDto>> GetAllAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 50);
        Task<DebtorDto> AddAsync(CreateDebtorDto createDto, string actor, CancellationToken cancellationToken);
        Task<DebtorDto> UpdateAsync(Guid id, DebtorDto debtorDto, string actor, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, string actor, CancellationToken cancellationToken);
        Task<ContactDto> AddContactAsync(Guid debtorId, CreateContactDto contactDto, string actor, CancellationToken cancellationToken);
        Task<ContactDto> UpdateContactAsync(Guid contactId, UpdateContactDto contactDto, string actor, CancellationToken cancellationToken);
        Task<ContactDto> GetContactByIdAsync(Guid contactId, CancellationToken cancellationToken);
    }
}
