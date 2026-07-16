using Microsoft.EntityFrameworkCore;
using WeatherAlertTracker.Application.Interfaces;
using WeatherAlertTracker.Domain.Entities;
using WeatherAlertTracker.Infrastructure.Data;

namespace WeatherAlertTracker.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _context;

    public CityRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<City> AddAsync(City city)
    {
        await _context.Cities.AddAsync(city);
        await _context.SaveChangesAsync();

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