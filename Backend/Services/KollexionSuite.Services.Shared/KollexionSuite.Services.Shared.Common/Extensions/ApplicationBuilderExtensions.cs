using KollexionSuite.Services.Shared.Middleware;
using Microsoft.AspNetCore.Builder;

namespace KollexionSuite.Services.Shared.Common.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSharedExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
