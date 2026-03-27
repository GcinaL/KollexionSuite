using KollexionSuite.Services.MessageBroker.Domain.Common;

namespace KollexionSuite.Services.MessageBroker.Domain.Entities
{
    public class TopicSubscription : BaseEntity
    {
        public string TopicName { get; private set; } = default!;
        public string CallbackUrl { get; private set; } = default!;
        public bool IsActive { get; private set; } = true;
        public string? Description { get; private set; }

        private TopicSubscription() { }

        public TopicSubscription(string topicName, string callbackUrl, string? description = null)
        {
            TopicName = topicName;
            CallbackUrl = callbackUrl;
            Description = description;
        }

        public void Update(string callbackUrl, string? description)
        {
            CallbackUrl = callbackUrl;
            Description = description;
            MarkUpdated();
        }

        public void Deactivate()
        {
            IsActive = false;
            MarkUpdated();
        }

        public void Activate()
        {
            IsActive = true;
            MarkUpdated();
        }
    }
}
