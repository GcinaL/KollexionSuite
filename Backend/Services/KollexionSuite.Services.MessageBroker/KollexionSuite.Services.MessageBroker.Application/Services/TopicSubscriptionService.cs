using KollexionSuite.Services.MessageBroker.Application.Contracts.Requests;
using KollexionSuite.Services.MessageBroker.Application.Contracts.Responses;
using KollexionSuite.Services.MessageBroker.Application.Interfaces;
using KollexionSuite.Services.MessageBroker.Domain.Common;
using KollexionSuite.Services.MessageBroker.Domain.Entities;
using KollexionSuite.Services.MessageBroker.Domain.IRepositories;

namespace KollexionSuite.Services.MessageBroker.Application.Services
{
    public sealed class TopicSubscriptionService : ITopicSubscriptionService
    {
        private readonly IMessageBrokerRepository<TopicSubscription> _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TopicSubscriptionService(IMessageBrokerRepository<TopicSubscription> subscriptionRepository,IUnitOfWork unitOfWork)
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TopicSubscriptionResponse> CreateAsync(TopicSubscriptionRequest request,CancellationToken cancellationToken = default)
        {
            var entity = new TopicSubscription(
                request.TopicName,
                request.CallbackUrl,
                request.Description);

            await _subscriptionRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return MapToResponse(entity);
        }

        public async Task<TopicSubscriptionResponse?> GetAsync(Guid id,CancellationToken cancellationToken = default)
        {
            var entity = await _subscriptionRepository.GetByIdAsync(id, cancellationToken);
            return entity is null ? null : MapToResponse(entity);
        }

        public async Task<IReadOnlyList<TopicSubscriptionResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _subscriptionRepository.ListAsync(cancellationToken: cancellationToken);
            return entities.Select(MapToResponse).ToList();
        }

        public async Task<TopicSubscriptionResponse?> UpdateAsync(Guid id,TopicSubscriptionRequest request,CancellationToken cancellationToken = default)
        {
            var entity = await _subscriptionRepository.GetByIdAsync(id, cancellationToken);
            if (entity is null) return null;

            entity.Update(request.CallbackUrl, request.Description);
            _subscriptionRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return MapToResponse(entity);
        }

        public async Task<bool> DeactivateAsync(Guid id,CancellationToken cancellationToken = default)
        {
            var entity = await _subscriptionRepository.GetByIdAsync(id, cancellationToken);
            if (entity is null) return false;

            entity.Deactivate();
            _subscriptionRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }

        private static TopicSubscriptionResponse MapToResponse(TopicSubscription entity)
        {
            return new()
            {
                Id = entity.Id,
                TopicName = entity.TopicName,
                CallbackUrl = entity.CallbackUrl,
                IsActive = entity.IsActive,
                Description = entity.Description
            };
        }
           
    }
}
