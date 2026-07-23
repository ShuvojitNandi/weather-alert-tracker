namespace WeatherAlertTracker.Application.DTOs.Alerts;

public class CreateAlertRequest
{
    public Guid CityId { get; set; }

    public string WeatherType { get; set; } = string.Empty;

    public double Threshold { get; set; }

    public string Email { get; set; } = string.Empty;
}