namespace WeatherAlertTracker.Application.DTOs.Alerts;

public class AlertSummaryResponse
{
    public Guid Id { get; set; }

    public string City { get; set; } = string.Empty;

    public string WeatherType { get; set; } = string.Empty;

    public double Threshold { get; set; }

    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}