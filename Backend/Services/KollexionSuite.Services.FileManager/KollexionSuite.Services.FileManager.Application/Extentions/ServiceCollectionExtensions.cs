
using KollexionSuite.Services.FileManager.Application.Interfaces;
using KollexionSuite.Services.FileManager.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.FileManager.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // repositories
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
