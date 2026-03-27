namespace KollexionSuite.Services.MessageBroker.Application.Contracts.Requests
{
    public sealed class TopicSubscriptionRequest
    {
        public string TopicName { get; set; } = default!;
        public string CallbackUrl { get; set; } = default!;
        public string? Description { get; set; }
    }
}
