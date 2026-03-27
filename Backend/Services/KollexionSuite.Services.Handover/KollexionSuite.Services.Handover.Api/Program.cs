using KollexionSuite.Services.Handover.Application.Extentions;
using KollexionSuite.Services.Handover.Application.Interfaces;
using KollexionSuite.Services.Handover.Infrastructure.Contracts;
using KollexionSuite.Services.Handover.Infrastructure.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpClient<IFileManagerClient, FileManagerClient>(client =>
{
    var baseUrl = builder.Configuration["Services:FileManagerBaseUrl"]
        ?? throw new InvalidOperationException("Missing configuration: Services:FileManagerBaseUrl");

    client.BaseAddress = new Uri(baseUrl);
});

// Generic downloader for blob Urls
builder.Services.AddHttpClient("FileDownloader");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (open for development)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

//app.UseSharedExceptionHandling();

app.MapControllers();

app.Run();
