using KollexionSuite.Services.Handover.Domain.Utilities;

namespace KollexionSuite.Services.Handover.Application.DTOs
{
    public class TemplateColumnDto
    {
        public int ColumnIndex { get; set; }
        public string ColumnHeader { get; set; } = "";
        public int TargetEntity { get; set; }
        public string TargetField { get; set; } = "";
        public bool IsRequired { get; set; }
    }

    public class TemplateColumnMappingDto
    {
        public int ColumnIndex { get; set; }
        public string ColumnHeader { get; set; } = "";
        public HandoverTargetEntity TargetEntity { get; set; }
        public string TargetField { get; set; } = "";
        public bool IsRequired { get; set; }
    }
}
