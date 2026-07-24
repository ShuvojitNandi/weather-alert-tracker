using Microsoft.EntityFrameworkCore;
using WeatherAlertTracker.Application.Interfaces;
using WeatherAlertTracker.Domain.Entities;
using WeatherAlertTracker.Infrastructure.Data;

namespace WeatherAlertTracker.Infrastructure.Repositories;

public class AlertRepository : IAlertRepository
{
    private readonly ApplicationDbContext _context;


    public AlertRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(Alert alert)
    {
        await _context.Alerts.AddAsync(alert);

        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<Alert>> GetAllAsync()
    {
        return await _context.Alerts
            .Include(a => a.City)
            .ToListAsync();
    }


    public async Task<Alert?> GetByIdAsync(Guid id)
    {
        return await _context.Alerts
            .Include(a => a.City)
            .FirstOrDefaultAsync(a => a.Id == id);
    }


    public async Task DeleteAsync(Alert alert)
    {
        _context.Alerts.Remove(alert);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Alert>> GetActiveAlertsAsync()
    {
        return await _context.Alerts
            .Where(a => a.IsActive)
            .ToListAsync();
    }
}