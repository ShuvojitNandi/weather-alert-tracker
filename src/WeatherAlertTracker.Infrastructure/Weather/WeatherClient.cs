using System.Text.Json;
using WeatherAlertTracker.Infrastructure.Weather.Models;

namespace WeatherAlertTracker.Infrastructure.Weather;
using Microsoft.Extensions.Logging;

public class WeatherClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<WeatherClient> _logger;

    public WeatherClient(
        HttpClient httpClient,
        ILogger<WeatherClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<WeatherResponseDto> GetCurrentWeatherAsync(
        double latitude,
        double longitude)
    {
        var url =
            $"v1/forecast?latitude={latitude}" +
            $"&longitude={longitude}" +
            $"&current=temperature_2m,wind_speed_10m";

        _logger.LogInformation(
            "Calling Open-Meteo API for Latitude={Latitude}, Longitude={Longitude}",
            latitude,
            longitude);

        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var weather =
            JsonSerializer.Deserialize<WeatherResponseDto>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        if (weather is null)
        {
            throw new Exception("Unable to deserialize weather response.");
        }

        _logger.LogInformation(
            "Weather received. Temperature={Temperature}, WindSpeed={WindSpeed}",
            weather.Current.Temperature,
            weather.Current.WindSpeed);

        return weather;
    }
}