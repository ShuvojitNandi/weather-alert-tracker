using Microsoft.Extensions.Logging;
using WeatherAlertTracker.Application.Interfaces;

namespace WeatherAlertTracker.Application.Services;

public class WeatherAlertEvaluator : IWeatherAlertEvaluator
{
    private readonly ILogger<WeatherAlertEvaluator> _logger;

    public WeatherAlertEvaluator(
        ILogger<WeatherAlertEvaluator> logger)
    {
        _logger = logger;
    }

    public async Task CheckAlertsAsync(
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Weather alert evaluation started.");

        await Task.CompletedTask;
    }
}