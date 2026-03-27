using KollexionSuite.Services.Handover.Domain.Utilities;

namespace KollexionSuite.Services.Handover.Application.DTOs
{
    public class TemplateDto
    {
        public Guid TemplateId { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public int FileType { get; set; }
        public List<TemplateColumnDto> Columns { get; set; } = new();
    }

    public class TemplatePreviewDto
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; } = "";
        public string FileType { get; set; } = "";
        public List<string> Columns { get; set; } = new();
    }
    public class CreateTemplateFromFileDto
    {
        public Guid FileId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public ImportFileType FileType { get; set; }
        public List<TemplateColumnMappingDto> Mappings { get; set; } = new();
    }
}
