namespace KollexionSuite.Services.Handover.Domain.Entities
{
    public class HandoverBatch
    {
        public Guid BatchId { get; set; }
        public Guid TemplateId { get; set; }
        public DateTime ImportedAtUtc { get; set; }

        public int TotalRecords { get; set; }
        public int SuccessfulRecords { get; set; }
        public int FailedRecords { get; set; }

        public ICollection<HandoverRecord> Records { get; set; } = new List<HandoverRecord>();

    }
}
