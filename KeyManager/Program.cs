using System.Reflection;
using KeyManager.Application;
using KeyManager.HealthCheck;
using KeyManager.Persistence.Data;
using KeyManager.Persistence.DatabaseModels;
using KeyManager.Persistence.Repositories;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets(Assembly.GetEntryAssembly()!);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository<Address>, AddressRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Key>, KeyRepository>();

builder.Services.AddProblemDetails(opts =>
    opts.CustomizeProblemDetails = (ctx) =>
    {
        if (ctx.ProblemDetails.Status == 500)
        {
            ctx.ProblemDetails.Detail = "An error occurred. Search log for traceId for more details";
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