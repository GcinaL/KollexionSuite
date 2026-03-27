namespace KollexionSuite.Services.MessageBroker.Application.Contracts.Responses
{
    public sealed class TopicSubscriptionResponse
    {
        public Guid Id { get; set; }
        public string TopicName { get; set; } = default!;
        public string CallbackUrl { get; set; } = default!;
        public bool IsActive { get; set; }
        public string? Description { get; set; }
    }
}
