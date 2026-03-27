namespace KollexionSuite.Services.Debtors.Domain.Entities
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public Guid DebtorId { get; set; }
        public string Type { get; set; } = string.Empty;   // Email, Mobile, HomePhone, Address
        public string Value { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? VerifiedAt { get; set; }
    }
}
