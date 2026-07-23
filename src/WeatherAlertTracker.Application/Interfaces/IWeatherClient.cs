using WeatherAlertTracker.Application.DTOs.Weather;

namespace WeatherAlertTracker.Application.Interfaces;

public interface IWeatherClient
{
    Task<WeatherResponseDto> GetCurrentWeatherAsync(
        double latitude,
        double longitude);
}