namespace KollexionSuite.Services.Shared.Common.DTOs
{
    public class EventMessageDto
    {
        public Enum EventType { get; init; }
        public object Payload { get; init; } = default!;
    }
}
