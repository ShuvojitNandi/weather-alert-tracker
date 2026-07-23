using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeatherAlertTracker.Application.Interfaces;
using WeatherAlertTracker.Domain.Entities;
using WeatherAlertTracker.Infrastructure.Data;

namespace WeatherAlertTracker.Infrastructure.Repositories;

public class AlertRepository : IAlertRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AlertRepository> _logger;

    public AlertRepository(
        ApplicationDbContext context,
        ILogger<AlertRepository> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task<Alert> AddAsync(Alert alert)
    {
        _logger.LogInformation(
            "Saving alert for CityId {CityId}",
            alert.CityId);

        _context.Alerts.Add(alert);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Alert saved successfully. AlertId: {AlertId}",
            alert.Id);

        return alert;
    }


    public async Task<IEnumerable<Alert>> GetAllAsync()
    {
        return await _context.Alerts
            .AsNoTracking()
            .ToListAsync();
    }


    public async Task<Alert?> GetByIdAsync(Guid id)
    {
        return await _context.Alerts
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }


    public async Task DeleteAsync(Alert alert)
    {
        _logger.LogInformation(
            "Deleting alert {AlertId}",
            alert.Id);

        _context.Alerts.Remove(alert);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Alert deleted successfully.");
    }
}