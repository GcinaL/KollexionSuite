using KollexionSuite.Services.MessageBroker.Domain.Common;
using KollexionSuite.Services.MessageBroker.Domain.Utilities;

namespace KollexionSuite.Services.MessageBroker.Domain.Models
{
    public sealed class OutboxEvent : BaseEntity
    {
        public string KafkaTopic { get; private set; } = default!;
        public string? Key { get; private set; }
        public string PayloadJson { get; private set; } = default!;

        public OutboxStatus Status { get; private set; } = OutboxStatus.Pending;
        public int RetryCount { get; private set; }
        public string? LastError { get; private set; }
        public DateTime? ProcessedAt { get; private set; }

        private OutboxEvent() { }

        public OutboxEvent(string kafkaTopic, string? key, string payloadJson)
        {
            KafkaTopic = kafkaTopic;
            Key = key;
            PayloadJson = payloadJson;
        }

        public void MarkInProgress()
        {
            Status = OutboxStatus.InProgress;
            MarkUpdated();
        }

        public void MarkPublished()
        {
            Status = OutboxStatus.Published;
            ProcessedAt = DateTime.Now;
            MarkUpdated();
        }

        public void MarkFailed(string error, bool deadLetter = false)
        {
            RetryCount++;
            LastError = error;
            Status = deadLetter ? OutboxStatus.DeadLetter : OutboxStatus.Failed;
            MarkUpdated();
        }

        public void ResetToPending()
        {
            Status = OutboxStatus.Pending;
            MarkUpdated();
        }
    }
}
