using Azure.Storage.Blobs;
using KollexionSuite.Services.FileManager.Domain.IRepositories;
using KollexionSuite.Services.FileManager.Infrastructure.Data;
using KollexionSuite.Services.FileManager.Infrastructure.Repositories;
using KollexionSuite.Services.FileManager.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.FileManager.Infrastructure.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<FileDbContext>(opts =>
                opts.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    sql => sql.EnableRetryOnFailure()));

            // repositories
            services.AddScoped<IFileRepository, FileRepository>();

            services.AddSingleton(new BlobServiceClient(config["AzureStorage:ConnectionString"]));

            services.AddScoped<AzureBlobStorageProvider>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<FileDbContext>();
                db.Database.EnsureCreated();
            }

            return services;
        }
    }
}
