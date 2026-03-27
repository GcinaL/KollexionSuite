using KollexionSuite.Services.Handover.Application.DTOs;

namespace KollexionSuite.Services.Handover.Application.Interfaces
{
    public interface IHandoverImportService
    {
        Task<ImportResultDto> ImportAsync(Guid templateId, Stream fileStream, string fileName, CancellationToken ct);
    }
}
