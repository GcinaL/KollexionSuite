using KollexionSuite.Services.Handover.Application.DTOs;
using KollexionSuite.Services.Handover.Application.Interfaces;
using KollexionSuite.Services.Handover.Application.Mappings;
using KollexionSuite.Services.Handover.Domain.IRepositories;
using KollexionSuite.Services.Handover.Domain.Utilities;

namespace KollexionSuite.Services.Handover.Application.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IEnumerable<IColumnExtractor> _extractors;
        private readonly ITemplateRepository _repo;

        public TemplateService(IEnumerable<IColumnExtractor> extractors, ITemplateRepository repo)
        {
            _extractors = extractors;
            _repo = repo;
        }

        public async Task<List<string>> ExtractColumnsAsync(Stream stream, ImportFileType fileType, CancellationToken ct)
        {
            var extractor = _extractors.FirstOrDefault(e => e.FileType == fileType)
                ?? throw new NotSupportedException($"No header extractor for {fileType}");

            return await extractor.ExtractHeadersAsync(stream, ct);
        }

        public async Task<TemplateDto> CreateTemplateFromFileAsync(CreateTemplateFromFileDto dto, CancellationToken ct)
        {
            var template = Mapper.MapToEntity(dto);

            await _repo.AddAsync(template, ct);

            return Mapper.MapToDto(template);
        }

        public async Task<TemplateDto> GetTemplateAsync(Guid templateId, CancellationToken ct)
        {
            var template = await _repo.GetByIdAsync(templateId, ct);
            if (template == null) throw new KeyNotFoundException($"Template with id {templateId} not found");

            return Mapper.MapToDto(template);
        }

       

    }
}
