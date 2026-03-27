using KollexionSuite.Services.MessageBroker.Application.Contracts.Requests;
using KollexionSuite.Services.MessageBroker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KollexionSuite.Services.MessageBroker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageBrokerService _messageBrokerService;

        public MessagesController(IMessageBrokerService messageBrokerService)
        {
            _messageBrokerService = messageBrokerService;
        }

        [HttpPost]
        public async Task<IActionResult> Publish([FromBody] PublishMessageRequest request, CancellationToken cancellationToken)
        {
            var id = await _messageBrokerService.EnqueueAsync(request, cancellationToken);
            return Accepted(new { OutboxEventId = id });
        }
    }
}
