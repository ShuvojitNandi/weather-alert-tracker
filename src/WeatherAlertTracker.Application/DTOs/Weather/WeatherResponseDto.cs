using System.Text.Json.Serialization;

namespace WeatherAlertTracker.Application.DTOs.Weather;

public class WeatherResponseDto
{
    [JsonPropertyName("current")]
    public CurrentWeatherDto Current { get; set; } = new();
}