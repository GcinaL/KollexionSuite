using KollexionSuite.Services.Handover.Domain.IRepositories;
using KollexionSuite.Services.Handover.Infrastructure.Data;
using KollexionSuite.Services.Handover.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Handover.Infrastructure.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<HandoverDbContext>(opts => opts.UseSqlServer(config.GetConnectionString("DefaultConnection"), sql => sql.EnableRetryOnFailure()));

            // repositories
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<IBatchRepository, BatchRepository>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<HandoverDbContext>();
                db.Database.EnsureCreated();
            }

            return services;
        }
    }
}
