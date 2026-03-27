
using KollexionSuite.Services.Shared.Utilities;

namespace KollexionSuite.Services.Shared.Common.DTOs
{
    public class CreateAuditDto
    {
        public string Actor { get; set; } = "system";// user or system
        public AuditAction Action { get; set; } // Create/Update/Delete
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public string? EntityBefore { get; set; } = null;
        public string? EntityAfter { get; set; } = null;
    }
}
