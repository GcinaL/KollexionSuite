using KollexionSuite.Services.Handover.Domain.Entities;

namespace KollexionSuite.Services.Handover.Domain.IRepositories
{
    public interface ITemplateRepository
    {
        Task<Template?> GetByIdAsync(Guid id, CancellationToken ct);
        Task AddAsync(Template template, CancellationToken ct);
    }
}
