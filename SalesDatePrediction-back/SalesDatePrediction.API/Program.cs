using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.API.Middlewares;
using SalesDatePrediction.Application.Common.Behaviors;
using SalesDatePrediction.Application.UseCases.Commands.CreateOrder;
using SalesDatePrediction.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:8080", "http://localhost:5000");

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

var conString = builder.Configuration.GetConnectionString("DefaultConnection") ??
     throw new InvalidOperationException("Connection string 'DefaultConnection'" +
    " not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(conString));

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//Global Exception Errors I
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

//MediatR
var assemblies = Assembly.Load("SalesDatePrediction.Application");

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(assemblies);
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//FluentValidation
builder.Services.AddValidatorsFromAssembly(assemblies);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


var app = builder.Build();

//Global Exception Errors II
app.UseExceptionHandler();
app.UseStatusCodePages();

//CORS II
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
