using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherAlertTracker.Application.Interfaces;

namespace WeatherAlertTracker.Application.BackgroundServices;

public class WeatherAlertMonitorService : BackgroundService
{
    private readonly ILogger<WeatherAlertMonitorService> _logger;
    
    private readonly IServiceScopeFactory _scopeFactory;


    public WeatherAlertMonitorService(
        ILogger<WeatherAlertMonitorService> logger,
        IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }


    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "Weather Alert Monitor started.");


        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation(
                "Checking weather alerts...");


            using var scope =
                _scopeFactory.CreateScope();


            var evaluator =
                scope.ServiceProvider
                    .GetRequiredService<IWeatherAlertEvaluator>();

            await evaluator.CheckAlertsAsync(stoppingToken);


            await Task.Delay(
                TimeSpan.FromMinutes(5),
                stoppingToken);
        }
    }
}