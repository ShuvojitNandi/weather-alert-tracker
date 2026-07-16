namespace WeatherAlertTracker.Domain.Entities;

public class Alert
{
    public Guid Id { get; set; }

    public Guid CityId { get; set; }

    public string WeatherType { get; set; } = string.Empty;

    public double Threshold { get; set; }

    public bool IsActive { get; set; } = true;

    public string Email { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public City City { get; set; } = null!;
}