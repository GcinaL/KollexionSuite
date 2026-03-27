using KollexionSuite.Services.Workflows.Domain.Common;
using KollexionSuite.Services.Workflows.Domain.IRepository;
using KollexionSuite.Services.Workflows.Infrastructure.Data;
using KollexionSuite.Services.Workflows.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Workflows.Infrastructure.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WorkflowDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.EnableRetryOnFailure()));

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<WorkflowDbContext>());
            services.AddScoped(typeof(IWorkflowRepository<>), typeof(WorkflowRepository<>));
            services.AddScoped<IWorkflowDefinitionRepository, WorkflowDefinitionRepository>();
            services.AddScoped<IWorkflowInstanceRepository, WorkflowInstanceRepository>();

            return services;
        }
    }
}
