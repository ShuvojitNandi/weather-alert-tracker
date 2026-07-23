namespace WeatherAlertTracker.Application.DTOs.Alerts;

public class AlertSummaryResponse
{
    public Guid Id { get; set; }

    public Guid CityId { get; set; }

    public string WeatherType { get; set; } = string.Empty;

    public double Threshold { get; set; }

    public bool IsActive { get; set; }
}