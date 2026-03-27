namespace KollexionSuite.Services.Shared.MessageBroker.Models
{
    public class OutboxMessage
    {
       public string EventType { get;set; } = string.Empty; //e.g., "UserCreated", "OrderPlaced"
       public string Payload { get;set; } = string.Empty; //JSON serialized event data

    }
}
