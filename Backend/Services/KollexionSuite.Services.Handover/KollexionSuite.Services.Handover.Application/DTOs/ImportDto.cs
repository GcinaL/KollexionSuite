namespace KollexionSuite.Services.Handover.Application.DTOs
{
    public class ImportRowErrorDto
    {
        public int RowIndex { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class ImportResultDto
    {
        public Guid BatchId { get; set; }
        public int TotalRecords { get; set; }
        public int SuccessfulRecords { get; set; }
        public int FailedRecords { get; set; }
        public List<ImportRowErrorDto> Errors { get; set; } = new();
    }

}
