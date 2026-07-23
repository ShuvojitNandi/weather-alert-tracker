namespace WeatherAlertTracker.Application.DTOs.Forecast;

public class ForecastResponse
{
    public string City { get; set; } = string.Empty;

    public double Temperature { get; set; }

    public double WindSpeed { get; set; }

    public string Time { get; set; } = string.Empty;
}