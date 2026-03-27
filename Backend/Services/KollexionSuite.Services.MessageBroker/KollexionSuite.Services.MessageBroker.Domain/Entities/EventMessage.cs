namespace KollexionSuite.Services.MessageBroker.Domain.Models
{
    public sealed class EventMessage
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime Timestamp { get; init; } = DateTime.Now;
        public Enum EventType { get; init; }
        public object Payload { get; init; } = default!;
    }
}
