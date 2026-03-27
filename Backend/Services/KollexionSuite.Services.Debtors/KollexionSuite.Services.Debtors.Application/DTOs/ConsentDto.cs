namespace KollexionSuite.Services.Debtors.Application.DTOs
{
    public class ConsentDto
    {
        public Guid ConsentId { get; set; }
        public string Channel { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public bool IsGranted { get; set; }
        public DateTime GivenAt { get; set; }
        public DateTime? ExpiryAt { get; set; }
        public string Source { get; set; } = string.Empty;
    }

    public class CreateConsentDto
    {
        public string Channel { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public bool IsGranted { get; set; }
        public string Source { get; set; } = string.Empty;
        public DateTime GivenAt { get; set; }
        public DateTime? ExpiryAt { get; set; }
    }

    public class UpdateConsentDto
    {
        public DateTime ExpiryAt { get; set; }
    }
}
