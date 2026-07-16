using WeatherAlertTracker.Domain.Entities;

namespace WeatherAlertTracker.Application.Interfaces;

public interface ICityRepository
{
    Task<City> AddAsync(City city);

    Task<IEnumerable<City>> GetAllAsync();

    Task<City?> GetByIdAsync(Guid id);

    Task DeleteAsync(City city);
}