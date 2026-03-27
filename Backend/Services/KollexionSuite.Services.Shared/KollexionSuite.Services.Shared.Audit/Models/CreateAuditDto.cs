using KollexionSuite.Services.Shared.Audit.Util;

namespace KollexionSuite.Services.Shared.Audit.Models
{
    public class CreateAuditDto
    {
        public string Actor { get; set; }
        public AuditAction Action { get; set; }   // Keep string for cross-service consistency
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public object? Before { get; set; }
        public object? After { get;set; }
    }
}
