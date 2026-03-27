using KollexionSuite.Services.Handover.Domain.Utilities;

namespace KollexionSuite.Services.Handover.Domain.Entities
{
    public class Template
    {
        public Guid TemplateId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } //Optional description, e.g. "Absa Bank - Vehicle Fin - Handover File Template"
        public ImportFileType FileType { get; set; }
        public ICollection<TemplateColumn> Columns { get; set; } = new List<TemplateColumn>();
    }
}
