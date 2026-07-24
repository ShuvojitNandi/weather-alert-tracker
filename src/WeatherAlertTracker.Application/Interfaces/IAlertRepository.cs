using WeatherAlertTracker.Domain.Entities;

namespace WeatherAlertTracker.Application.Interfaces;

public interface IAlertRepository
{
    Task AddAsync(Alert alert);

    Task<IEnumerable<Alert>> GetAllAsync();

    Task<IEnumerable<Alert>> GetActiveAlertsAsync();

    Task<Alert?> GetByIdAsync(Guid id);

    Task DeleteAsync(Alert alert);
}