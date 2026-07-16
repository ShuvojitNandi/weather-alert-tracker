namespace WeatherAlertTracker.Application.DTOs.Cities;

public class CitySummaryResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Province { get; set; } = string.Empty;
}