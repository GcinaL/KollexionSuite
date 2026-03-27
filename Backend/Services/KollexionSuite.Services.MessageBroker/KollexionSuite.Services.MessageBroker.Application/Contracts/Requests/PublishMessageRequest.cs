namespace KollexionSuite.Services.MessageBroker.Application.Contracts.Requests
{
    public sealed class PublishMessageRequest
    {
        public string KafkaTopic { get; set; } = default!;
        public string? Key { get; set; }
        public string Message { get; set; } = default!;
    }
}
