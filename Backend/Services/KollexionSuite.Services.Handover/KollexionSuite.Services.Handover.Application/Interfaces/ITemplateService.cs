using KollexionSuite.Services.Handover.Application.DTOs;
using KollexionSuite.Services.Handover.Domain.Utilities;

namespace KollexionSuite.Services.Handover.Application.Interfaces
{
    public interface ITemplateService
    {
        Task<List<string>> ExtractColumnsAsync(Stream stream, ImportFileType fileType, CancellationToken ct);
        Task<TemplateDto> CreateTemplateFromFileAsync(CreateTemplateFromFileDto dto, CancellationToken ct);
        Task<TemplateDto> GetTemplateAsync(Guid templateId, CancellationToken ct);
    }
}
