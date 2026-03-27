namespace KollexionSuite.Services.Debtors.Application.DTOs
{
    public class ContactDto
    {
        public Guid ContactId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? VerifiedAt { get; set; }
    }

    public class CreateContactDto
    {
        public string Type { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public bool IsValid { get; set; }
    }

    public class UpdateContactDto
    {
        public bool IsPrimary { get; set; } = default;
        public bool IsValid { get; set; } = default;
    }
}
