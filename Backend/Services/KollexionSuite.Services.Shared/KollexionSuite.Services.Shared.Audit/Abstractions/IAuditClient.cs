using KollexionSuite.Services.Shared.Audit.Models;

namespace KollexionSuite.Services.Shared.Audit.Abstractions
{
    public interface IAuditClient
    {
        Task AddAsync(CreateAuditDto dto, CancellationToken cancellationToken = default);
    }
}
