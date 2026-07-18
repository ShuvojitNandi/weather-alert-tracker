using Microsoft.EntityFrameworkCore;
using WeatherAlertTracker.Infrastructure.Data;

using WeatherAlertTracker.Application.Interfaces;
using WeatherAlertTracker.Application.Services;
using WeatherAlertTracker.Infrastructure.Repositories;

using FluentValidation;
using FluentValidation.AspNetCore;
using WeatherAlertTracker.Application.DTOs.Cities;
using WeatherAlertTracker.Application.Validators;

using WeatherAlertTracker.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddValidatorsFromAssemblyContaining<CreateCityRequestValidator>();

builder.Services.AddFluentValidationAutoValidation();

// Register PostgreSQL DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddScoped<ICityService, CityService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();