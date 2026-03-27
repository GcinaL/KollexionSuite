namespace KollexionSuite.Services.Debtors.Domain.Entities
{
    public class Consent
    {
        public Guid ConsentId { get; set; }
        public Guid DebtorId { get; set; }
        public string Channel { get; set; } = string.Empty; // SMS, Email, WhatsApp, Voice
        public string Purpose { get; set; } = string.Empty; // e.g. Marketing, Collections
        public bool IsGranted { get; set; }
        public DateTime GivenAt { get; set; }
        public DateTime? ExpiryAt { get; set; }
        public string Source { get; set; } = string.Empty;  // e.g. Portal, Agent, Imported
    }
}
