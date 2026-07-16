using WeatherAlertTracker.Application.DTOs.Cities;

namespace WeatherAlertTracker.Application.Interfaces;

public interface ICityService
{
    Task<CityResponse> CreateAsync(CreateCityRequest request);

    Task<IEnumerable<CitySummaryResponse>> GetAllAsync();

    Task<CityResponse?> GetByIdAsync(Guid id);

    Task DeleteAsync(Guid id);
}