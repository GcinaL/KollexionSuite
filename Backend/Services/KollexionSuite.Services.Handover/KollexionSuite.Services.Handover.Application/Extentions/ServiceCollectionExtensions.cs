using KollexionSuite.Services.Handover.Application.ColumnExtraction;
using KollexionSuite.Services.Handover.Application.FileParsing;
using KollexionSuite.Services.Handover.Application.Interfaces;
using KollexionSuite.Services.Handover.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Handover.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Column extractors
            services.AddScoped<IColumnExtractor, ExcelColumnExtractor>();
            services.AddScoped<IColumnExtractor, CsvColumnExtractor>();
            services.AddScoped<IColumnExtractor, JsonColumnExtractor>();
            services.AddScoped<IColumnExtractor, XmlColumnExtractor>();

            // File parsers for import
            services.AddScoped<IFileParser, CsvFileParser>();

            //Services
            services.AddScoped<IHandoverImportService, HandoverImportService>();
            services.AddScoped<ITemplateService, TemplateService>();

            return services;
        }
    }
}
