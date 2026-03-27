namespace KollexionSuite.Services.Debtors.Domain.Entities
{
    public class Identifier
    {
        public Guid IdentifierId { get; set; }
        public Guid DebtorId { get; set; }
        public string IdentifierType { get; set; } = string.Empty; // National Id, Passport
        public string IdentifierValue { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
