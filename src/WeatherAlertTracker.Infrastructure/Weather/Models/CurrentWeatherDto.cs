using System.Text.Json.Serialization;

namespace WeatherAlertTracker.Infrastructure.Weather.Models;

public class CurrentWeatherDto
{
    [JsonPropertyName("temperature_2m")]
    public double Temperature { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public double WindSpeed { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;
}