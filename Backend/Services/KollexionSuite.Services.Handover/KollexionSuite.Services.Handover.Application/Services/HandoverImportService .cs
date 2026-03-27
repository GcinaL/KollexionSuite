using KollexionSuite.Services.Handover.Application.DTOs;
using KollexionSuite.Services.Handover.Application.Interfaces;
using KollexionSuite.Services.Handover.Application.Mappings;
using KollexionSuite.Services.Handover.Domain.Entities;
using KollexionSuite.Services.Handover.Domain.IRepositories;

namespace KollexionSuite.Services.Handover.Application.Services
{
    public class HandoverImportService : IHandoverImportService
    {
        private readonly ITemplateRepository _templateRepo;
        private readonly IBatchRepository _batchRepo;
        private readonly IEnumerable<IFileParser> _parsers;

        public HandoverImportService(ITemplateRepository templateRepo, IBatchRepository batchRepo, IEnumerable<IFileParser> parsers)
        {
            _templateRepo = templateRepo;
            _batchRepo = batchRepo;
            _parsers = parsers;
        }

        public async Task<ImportResultDto> ImportAsync(Guid templateId,Stream fileStream,string fileName,CancellationToken ct)
        {
            var template = await _templateRepo.GetByIdAsync(templateId, ct) ?? throw new InvalidOperationException("Template not found.");

            var fileType = FileTypeHelper.FromFileName(fileName);

            if (fileType != template.FileType) throw new InvalidOperationException($"Template expects {template.FileType} but file is {fileType}.");

            var parser = _parsers.FirstOrDefault(p => p.FileType == fileType) ?? throw new InvalidOperationException($"No parser registered for {fileType}.");

            var rows = await parser.ParseAsync(fileStream, ct);

            var batch = new HandoverBatch
            {
                BatchId = Guid.NewGuid(),
                TemplateId = template.TemplateId,
                ImportedAtUtc = DateTime.UtcNow,
                TotalRecords = rows.Count
            };

            var result = new ImportResultDto
            {
                BatchId = batch.BatchId,
                TotalRecords = rows.Count
            };

            foreach (var row in rows)
            {
                try
                {
                    var mapped = Mapper.MapRowToObject(template, row);

                    var record = new HandoverRecord
                    {
                        HandoverRecordId = Guid.NewGuid(),
                        BatchId = batch.BatchId,
                        RowIndex = row.RowIndex,
                        RawDataJson = System.Text.Json.JsonSerializer.Serialize(mapped),
                        IsProcessed = true
                    };

                    batch.Records.Add(record);
                    result.SuccessfulRecords++;
                }
                catch (Exception ex)
                {
                    var record = new HandoverRecord
                    {
                        HandoverRecordId = Guid.NewGuid(),
                        BatchId = batch.BatchId,
                        RowIndex = row.RowIndex,
                        RawDataJson = "",
                        IsProcessed = false,
                        ErrorMessage = ex.Message
                    };

                    batch.Records.Add(record);
                    result.FailedRecords++;
                    result.Errors.Add(new ImportRowErrorDto
                    {
                        RowIndex = row.RowIndex,
                        ErrorMessage = ex.Message
                    });
                }
            }

            await _batchRepo.AddAsync(batch, ct);
            await _batchRepo.SaveChangesAsync(ct);

            return result;
        }
    }
}
