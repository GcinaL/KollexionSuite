using KollexionSuite.Services.Shared.Common.ApiModels;
using KollexionSuite.Services.Shared.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace KollexionSuite.Services.Shared.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, ex.Message, StatusCodes.Status404NotFound);
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(context, ex.Message, StatusCodes.Status400BadRequest);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(context, ex.Message, StatusCodes.Status422UnprocessableEntity, ex.Errors);
            }
            catch (UnauthorizedException ex)
            {
                await HandleExceptionAsync(context, ex.Message, StatusCodes.Status401Unauthorized);
            }
            catch (ForbiddenException ex)
            {
                await HandleExceptionAsync(context, ex.Message, StatusCodes.Status403Forbidden);
            }
            catch (ConflictException ex)
            {
                await HandleExceptionAsync(context, ex.Message, StatusCodes.Status409Conflict);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");
                await HandleExceptionAsync(context, "An unexpected error occurred.", StatusCodes.Status500InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string message, int statusCode, object? details = null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = ApiResponse<string>.Fail(message, statusCode, details);
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
