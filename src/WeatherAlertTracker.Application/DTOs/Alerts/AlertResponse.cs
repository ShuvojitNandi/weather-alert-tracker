namespace WeatherAlertTracker.Application.DTOs.Alerts;

public class AlertResponse
{
    public Guid Id { get; set; }

    public Guid CityId { get; set; }

    public string WeatherType { get; set; } = string.Empty;

    public double Threshold { get; set; }

    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}