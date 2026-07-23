using WeatherAlertTracker.Application.DTOs.Alerts;

namespace WeatherAlertTracker.Application.Interfaces;

public interface IAlertService
{
    Task<AlertResponse> CreateAsync(CreateAlertRequest request);

    Task<IEnumerable<AlertSummaryResponse>> GetAllAsync();

    Task<AlertResponse?> GetByIdAsync(Guid id);

    Task DeleteAsync(Guid id);
}