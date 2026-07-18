using Microsoft.EntityFrameworkCore;
using WeatherAlertTracker.Application.Interfaces;
using WeatherAlertTracker.Domain.Entities;
using WeatherAlertTracker.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace WeatherAlertTracker.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CityRepository> _logger;


    public CityRepository(
        ApplicationDbContext context,
        ILogger<CityRepository> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task<City> AddAsync(City city)
    {
        _logger.LogInformation(
            "Saving city {CityName} to database",
            city.Name);


        await _context.Cities.AddAsync(city);

        await _context.SaveChangesAsync();


        _logger.LogInformation(
            "City saved successfully. Id: {CityId}",
            city.Id);


        return city;
    }


    public async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _context.Cities
            .AsNoTracking()
            .ToListAsync();
    }


    public async Task<City?> GetByIdAsync(Guid id)
    {
        return await _context.Cities
            .FirstOrDefaultAsync(c => c.Id == id);
    }


    public async Task DeleteAsync(City city)
    {
        _context.Cities.Remove(city);

        await _context.SaveChangesAsync();
    }
}