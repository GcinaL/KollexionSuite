using KollexionSuite.Services.Handover.Application.DTOs;
using KollexionSuite.Services.Handover.Application.FileParsing;
using KollexionSuite.Services.Handover.Domain.Entities;
using KollexionSuite.Services.Handover.Domain.Utilities;
namespace KollexionSuite.Services.Handover.Application.Mappings
{
    public static class Mapper
    {
        public static Template MapToEntity(CreateTemplateFromFileDto dto)
        {
            var template = new Template()
            {
                TemplateId = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                FileType = dto.FileType
            };

            template.Columns = dto.Mappings.Select(m => new TemplateColumn
            {
                TemplateColumnId = Guid.NewGuid(),
                TemplateId = template.TemplateId,
                ColumnIndex = m.ColumnIndex,
                ColumnHeader = m.ColumnHeader,
                TargetEntity = m.TargetEntity,
                TargetField = m.TargetField,
                IsRequired = m.IsRequired
            }).ToList();

            return template;
        }

        public static TemplateDto MapToDto(Template template)
        {
            return new TemplateDto()
            {
                TemplateId = template.TemplateId,
                Name = template.Name,
                Description = template.Description,
                FileType = (int)template.FileType,
                Columns = template.Columns
                .OrderBy(c => c.ColumnIndex)
                .Select(c => new TemplateColumnDto
                {
                    ColumnIndex = c.ColumnIndex,
                    ColumnHeader = c.ColumnHeader,
                    TargetEntity = (int)c.TargetEntity,
                    TargetField = c.TargetField,
                    IsRequired = c.IsRequired
                }).ToList()
            };
        }

        public static object MapRowToObject(Template template, ParsedRow row)
        {
            var debtor = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
            var contacts = new List<Dictionary<string, string?>>();
            var addresses = new List<Dictionary<string, string?>>();

            foreach (var col in template.Columns)
            {
                string? value = null;

                if (row.ByIndex.TryGetValue(col.ColumnIndex, out var byIndexValue))
                    value = byIndexValue;
                else if (!string.IsNullOrWhiteSpace(col.ColumnHeader)
                         && row.ByHeader.TryGetValue(col.ColumnHeader, out var byHeaderValue))
                    value = byHeaderValue;

                if (col.IsRequired && string.IsNullOrWhiteSpace(value))
                    throw new InvalidOperationException($"Required field missing at row {row.RowIndex}: {col.TargetEntity}.{col.TargetField}");

                if (string.IsNullOrWhiteSpace(value))
                    continue;

                switch (col.TargetEntity)
                {
                    case HandoverTargetEntity.Debtor:
                        debtor[col.TargetField] = value;
                        break;

                    case HandoverTargetEntity.Contact:
                        contacts.Add(new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase)
                        {
                            ["Field"] = col.TargetField,
                            ["Value"] = value
                        });
                        break;

                    case HandoverTargetEntity.Address:
                        addresses.Add(new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase)
                        {
                            ["Field"] = col.TargetField,
                            ["Value"] = value
                        });
                        break;
                }
            }

            return new
            {
                Debtor = debtor,
                Contacts = contacts,
                Addresses = addresses
            };
        }

    }
}
