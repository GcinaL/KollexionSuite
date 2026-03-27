namespace KollexionSuite.Services.Shared.Common.DTOs
{
    public class OutboxEventDto
    {
        public string KafkaTopic { get; set; }
        public EventMessageDto EventMessageDto { get; set; }
    }
}
