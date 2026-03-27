namespace KollexionSuite.Services.Auditing.Application.DTOs
{
    public class AuditDto
    {
        public Guid EventId { get; set; }
        public string Actor { get; set; } // user or system
        public string Action { get; set; } // Create/Update/Delete
        public string EntityType { get; set; }
        public Guid EntityId { get; set; }
        public DateTime At { get; set; }
        public string? Before { get; set; }
        public string? After { get; set; }
    }
}
