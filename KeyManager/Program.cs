using System.Reflection;
using KeyManager.Application;
using KeyManager.Domain.Models;
using KeyManager.HealthCheck;
using KeyManager.Persistence.Data;
using KeyManager.Persistence.Repositories;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets(Assembly.GetEntryAssembly()!);


var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithThreadId()
    .Enrich.WithThreadName()
    .CreateLogger();

Log.Logger = logger;
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Property>, PropertyRepository>();
builder.Services.AddScoped<IRepository<Resident>, ResidentRepository>();
builder.Services.AddScoped<IRepository<Key>, KeyRepository>();

builder.Services.AddProblemDetails(opts =>
    opts.CustomizeProblemDetails = (ctx) =>
    {
        if (ctx.ProblemDetails.Status == 500)
        {
            ctx.ProblemDetails.Detail = "An error occurred. Search log for traceId to more details";
        }
    }
);
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    // Adds examples
    options.ExampleFilters();
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResultStatusCodes = HealthCheckMappings.ResultStatusCodes
});

app.UseExceptionHandler();

app.MapControllers();

app.Run();