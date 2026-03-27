using KollexionSuite.Services.MessageBroker.Application.Contracts.Requests;
using KollexionSuite.Services.MessageBroker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KollexionSuite.Services.MessageBroker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ITopicSubscriptionService _subscriptionService;

        public SubscriptionsController(ITopicSubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _subscriptionService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _subscriptionService.GetAsync(id, cancellationToken);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TopicSubscriptionRequest request,CancellationToken cancellationToken)
        {
            var result = await _subscriptionService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] TopicSubscriptionRequest request,CancellationToken cancellationToken)
        {
            var result = await _subscriptionService.UpdateAsync(id, request, cancellationToken);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deactivate(Guid id, CancellationToken cancellationToken)
        {
            var success = await _subscriptionService.DeactivateAsync(id, cancellationToken);
            return success ? NoContent() : NotFound();
        }
    }
}
