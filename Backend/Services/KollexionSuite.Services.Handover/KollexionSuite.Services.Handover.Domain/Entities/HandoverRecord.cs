namespace KollexionSuite.Services.Handover.Domain.Entities
{
    public class HandoverRecord
    {
        public Guid HandoverRecordId { get; set; }
        public Guid BatchId { get; set; }

        public int RowIndex { get; set; }
        public string RawDataJson { get; set; } = "";
        public bool IsProcessed { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
