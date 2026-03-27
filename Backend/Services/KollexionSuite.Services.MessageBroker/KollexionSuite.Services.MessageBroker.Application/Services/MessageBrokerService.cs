using KollexionSuite.Services.MessageBroker.Application.Contracts.Requests;
using KollexionSuite.Services.MessageBroker.Application.Interfaces;
using KollexionSuite.Services.MessageBroker.Domain.Common;
using KollexionSuite.Services.MessageBroker.Domain.IRepositories;
using KollexionSuite.Services.MessageBroker.Domain.Models;

namespace KollexionSuite.Services.MessageBroker.Application.Services
{
    public sealed class MessageBrokerService : IMessageBrokerService
    {
        private readonly IOutboxEventRepository _outboxRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageBrokerService(IOutboxEventRepository outboxRepository, IUnitOfWork unitOfWork)
        {
            _outboxRepository = outboxRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> EnqueueAsync(PublishMessageRequest request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request.KafkaTopic))
                throw new ArgumentException("KafkaTopic is required.", nameof(request.KafkaTopic));
            if (string.IsNullOrWhiteSpace(request.Message))
                throw new ArgumentException("Message is required.", nameof(request.Message));

            var outboxEvent = new OutboxEvent(
                request.KafkaTopic,
                request.Key,
                request.Message);

            await _outboxRepository.AddAsync(outboxEvent, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return outboxEvent.Id;
        }
    }
}
