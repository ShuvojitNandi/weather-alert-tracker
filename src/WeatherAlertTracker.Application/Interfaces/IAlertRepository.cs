using WeatherAlertTracker.Domain.Entities;

namespace WeatherAlertTracker.Application.Interfaces;

public interface IAlertRepository
{
    Task<Alert> AddAsync(Alert alert);

    Task<IEnumerable<Alert>> GetAllAsync();

    Task<Alert?> GetByIdAsync(Guid id);

    Task DeleteAsync(Alert alert);
}