using KollexionSuite.Services.Handover.Domain.Utilities;

namespace KollexionSuite.Services.Handover.Domain.Entities
{
    public class TemplateColumn
    {
        public Guid TemplateColumnId { get; set; }
        public Guid TemplateId { get; set; }

        public int ColumnIndex { get; set; }
        public string ColumnHeader { get; set; } = "";
        public HandoverTargetEntity TargetEntity { get; set; }
        public string TargetField { get; set; } = "";
        public bool IsRequired { get; set; }
    }
}
