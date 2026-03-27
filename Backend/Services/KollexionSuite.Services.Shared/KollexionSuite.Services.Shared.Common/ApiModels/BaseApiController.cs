using Microsoft.AspNetCore.Mvc;

namespace KollexionSuite.Services.Shared.Common.ApiModels
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult Success<T>(T data) =>
            Ok(ApiResponse<T>.Ok(data));

        protected IActionResult CreatedAt<T>(string actionName, object routeValues, T data) =>
            base.CreatedAtAction(actionName, routeValues, ApiResponse<T>.Ok(data));

        protected IActionResult NoContentSuccess() =>
            NoContent();
    }
}
