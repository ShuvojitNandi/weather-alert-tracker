namespace WeatherAlertTracker.Application.Interfaces;

public interface IWeatherAlertEvaluator
{
    Task CheckAlertsAsync(CancellationToken cancellationToken);
}