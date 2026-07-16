namespace WeatherAlertTracker.Application.DTOs.Cities;

public class CityResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Province { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public DateTime CreatedAt { get; set; }
}