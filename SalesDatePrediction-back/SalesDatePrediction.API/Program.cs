using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.API.Middlewares;
using SalesDatePrediction.Application.Common.Behaviors;
using SalesDatePrediction.Application.UseCases.Commands.CreateOrder;
using SalesDatePrediction.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("DefaultConnection") ??
     throw new InvalidOperationException("Connection string 'AppDbContext'" +
    " not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(conString));

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
