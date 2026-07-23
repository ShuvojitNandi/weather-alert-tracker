using Microsoft.Extensions.Logging;
using WeatherAlertTracker.Application.DTOs.Forecast;
using WeatherAlertTracker.Application.Interfaces;

namespace WeatherAlertTracker.Application.Services;

public class ForecastService
{
    private readonly ICityRepository _cityRepository;
    private readonly IWeatherClient _weatherClient;
    private readonly ILogger<ForecastService> _logger;

    public ForecastService(
        ICityRepository cityRepository,
        IWeatherClient weatherClient,
        ILogger<ForecastService> logger)
    {
        _cityRepository = cityRepository;
        _weatherClient = weatherClient;
        _logger = logger;
    }

    public async Task<ForecastResponse?> GetForecastAsync(Guid cityId)
    {
        _logger.LogInformation("Retrieving forecast for city {CityId}", cityId);

        var city = await _cityRepository.GetByIdAsync(cityId);

        if (city is null)
        {
            _logger.LogWarning("City {CityId} not found.", cityId);
            return null;
        }

        var weather = await _weatherClient.GetCurrentWeatherAsync(
            city.Latitude,
            city.Longitude);

        return new ForecastResponse
        {
            City = city.Name,
            Temperature = weather.Current.Temperature,
            WindSpeed = weather.Current.WindSpeed,
            Time = weather.Current.Time
        };
    }
}