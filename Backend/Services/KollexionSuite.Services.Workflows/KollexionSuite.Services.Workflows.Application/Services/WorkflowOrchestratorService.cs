using KollexionSuite.Services.Shared.Workflows.Models.Events;
using KollexionSuite.Services.Shared.Workflows.Models.Requests;
using KollexionSuite.Services.Workflows.Application.Interfaces;
using KollexionSuite.Services.Workflows.Domain.Common;
using KollexionSuite.Services.Workflows.Domain.Entities;
using KollexionSuite.Services.Workflows.Domain.IRepository;
using System.Text.Json;

namespace KollexionSuite.Services.Workflows.Application.Services
{
    public sealed class WorkflowOrchestratorService : IWorkflowOrchestratorService
    {
        private readonly IWorkflowDefinitionRepository _workflowDefinitionRepository;
        private readonly IWorkflowInstanceRepository _workflowInstanceRepository;
        private readonly IWorkflowRepository<WorkflowStepInstance> _workflowStepInstanceRepository;
        private readonly IMessageBrokerClient _messageBrokerClient;
        private readonly IUnitOfWork _unitOfWork;

        public WorkflowOrchestratorService(IWorkflowDefinitionRepository workflowDefinitionRepository,IWorkflowInstanceRepository workflowInstanceRepository,IWorkflowRepository<WorkflowStepInstance> workflowStepInstanceRepository,IMessageBrokerClient messageBrokerClient,IUnitOfWork unitOfWork)
        {
            _workflowDefinitionRepository = workflowDefinitionRepository;
            _workflowInstanceRepository = workflowInstanceRepository;
            _workflowStepInstanceRepository = workflowStepInstanceRepository;
            _messageBrokerClient = messageBrokerClient;
            _unitOfWork = unitOfWork;
        }

        public async Task<WorkflowDefinition> RegisterWorkflowDefinitionAsync(RegisterWorkflowDefinitionRequest request,CancellationToken cancellationToken = default)
        {
            var existing = await _workflowDefinitionRepository
                .GetByNameAsync(request.Name, cancellationToken);

            if (existing is not null)
                throw new InvalidOperationException($"Workflow '{request.Name}' already exists.");

            var definition = new WorkflowDefinition(request.Name, request.Description);

            foreach (var dto in request.Steps.OrderBy(s => s.Order))
            {
                var step = new WorkflowStepDefinition(
                    definition.Id,
                    dto.Order,
                    dto.StepName,
                    dto.RequestTopic,
                    dto.ResultTopic,
                    TimeSpan.FromSeconds(dto.TimeoutSeconds),
                    dto.CompensationTopic
                );

                definition.AddStep(step);
            }

            await _workflowDefinitionRepository.AddAsync(definition, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return definition;
        }

        public async Task<Guid> StartWorkflowAsync(StartWorkflowRequest request, CancellationToken cancellationToken = default)
        {
            var definition = await _workflowDefinitionRepository
                .GetByNameAsync(request.WorkflowName, cancellationToken);

            if (definition is null || !definition.IsActive) throw new InvalidOperationException("Workflow definition not found or inactive.");

            var instance = new WorkflowInstance(definition.Id, request.CorrelationId);
            instance.MarkInProgress();

            // Pre-create all step instances so we can track them properly
            var orderedSteps = definition.Steps.OrderBy(s => s.Order).ToList();
            foreach (var stepDef in orderedSteps)
            {
                instance.AddStepInstance(stepDef.Id, stepDef.Order);
            }

            await _workflowInstanceRepository.AddAsync(instance, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // Trigger first step
            if (orderedSteps.Any())
            {
                var firstStepDef = orderedSteps.First();
                var firstStepInstance = instance.Steps.Single(s => s.Order == firstStepDef.Order);
                firstStepInstance.MarkRequested(request.InitialPayloadJson);

                await _workflowStepInstanceRepository.AddAsync(firstStepInstance, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var evt = new WorkflowStepRequestedEvent
                {
                    WorkflowInstanceId = instance.Id,
                    StepInstanceId = firstStepInstance.Id,
                    StepName = firstStepDef.StepName,
                    CorrelationId = instance.CorrelationId,
                    PayloadJson = request.InitialPayloadJson
                };

                var payload = JsonSerializer.Serialize(evt);

                await _messageBrokerClient.PublishAsync(firstStepDef.RequestTopic, instance.CorrelationId, payload, cancellationToken);
            }

            return instance.Id;
        }

        public async Task HandleStepResultAsync(WorkflowStepResultEvent resultEvent,CancellationToken cancellationToken = default)
        {
            var instance = await _workflowInstanceRepository.GetActiveByIdAsync(resultEvent.WorkflowInstanceId, cancellationToken);

            if (instance is null)
            {
                // Could log a warning & ignore (idempotency / late message)
                return;
            }

            var stepInstance = instance.Steps.SingleOrDefault(s => s.Id == resultEvent.StepInstanceId);
            if (stepInstance is null)
            {
                // log & ignore
                return;
            }

            if (resultEvent.Success)
            {
                stepInstance.MarkSucceeded(resultEvent.ResultPayloadJson);

                // Determine next step
                var definitionSteps = instance.WorkflowDefinition.Steps.OrderBy(s => s.Order).ToList();
                var currentDef = definitionSteps.Single(s => s.Id == stepInstance.WorkflowStepDefinitionId);
                var currentIndex = definitionSteps.IndexOf(currentDef);
                var hasNext = currentIndex < definitionSteps.Count - 1;

                if (!hasNext)
                {
                    instance.MarkCompleted();
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return;
                }

                var nextDef = definitionSteps[currentIndex + 1];
                var nextInstance = instance.Steps.Single(s => s.WorkflowStepDefinitionId == nextDef.Id);

                nextInstance.MarkRequested(resultEvent.ResultPayloadJson);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var evt = new WorkflowStepRequestedEvent
                {
                    WorkflowInstanceId = instance.Id,
                    StepInstanceId = nextInstance.Id,
                    StepName = nextDef.StepName,
                    CorrelationId = instance.CorrelationId,
                    PayloadJson = resultEvent.ResultPayloadJson
                };

                var payload = JsonSerializer.Serialize(evt);
                await _messageBrokerClient.PublishAsync(nextDef.RequestTopic, instance.CorrelationId, payload, cancellationToken);
            }
            else
            {
                // mark failed and (optionally) kick off compensation logic
                stepInstance.MarkFailed(resultEvent.ErrorMessage ?? "Unknown error");
                instance.MarkFailed();

                // TODO: You can add compensation orchestration here using CompensationTopic

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
