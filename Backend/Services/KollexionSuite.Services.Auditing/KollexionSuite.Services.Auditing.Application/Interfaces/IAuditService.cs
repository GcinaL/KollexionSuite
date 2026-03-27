using KollexionSuite.Services.Auditing.Application.DTOs;
using KollexionSuite.Services.Shared.Audit.Models;

namespace KollexionSuite.Services.Auditing.Application.Interfaces
{
    public interface IAuditService
    {
        Task<IEnumerable<AuditDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<AuditDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<AuditDto> AddAsync(CreateAuditDto createAuditDto, CancellationToken cancellationToken);
    }
}
