namespace KollexionSuite.Services.Debtors.Application.DTOs
{
    public class IdentifierDto
    {
        public string IdentifierType { get; set; } = string.Empty; // National Id, Passport
        public string IdentifierValue { get; set; } = string.Empty;
    }
}
