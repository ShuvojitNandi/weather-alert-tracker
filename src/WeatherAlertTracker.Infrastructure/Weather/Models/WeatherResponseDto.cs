using System.Text.Json.Serialization;

namespace WeatherAlertTracker.Infrastructure.Weather.Models;

public class WeatherResponseDto
{
    [JsonPropertyName("current")]
    public CurrentWeatherDto Current { get; set; } = new();
}