using Microsoft.Extensions.Logging;
using WeatherAlertTracker.Application.DTOs.Alerts;
using WeatherAlertTracker.Application.Interfaces;
using WeatherAlertTracker.Domain.Entities;

namespace WeatherAlertTracker.Application.Services;

public class AlertService : IAlertService
{
    private readonly IAlertRepository _alertRepository;
    private readonly ICityRepository _cityRepository;
    private readonly ILogger<AlertService> _logger;


    public AlertService(
        IAlertRepository alertRepository,
        ICityRepository cityRepository,
        ILogger<AlertService> logger)
    {
        _alertRepository = alertRepository;
        _cityRepository = cityRepository;
        _logger = logger;
    }


    public async Task<AlertResponse> CreateAsync(CreateAlertRequest request)
    {
        _logger.LogInformation(
            "Creating alert for CityId {CityId}",
            request.CityId);


        var city = await _cityRepository.GetByIdAsync(request.CityId);

        if (city == null)
        {
            throw new InvalidOperationException(
                "City not found.");
        }


        var alert = new Alert
        {
            Id = Guid.NewGuid(),
            CityId = request.CityId,
            WeatherType = request.WeatherType,
            Threshold = request.Threshold,
            Email = request.Email,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };


        await _alertRepository.AddAsync(alert);


        _logger.LogInformation(
            "Alert created successfully. AlertId {AlertId}",
            alert.Id);


        return MapToResponse(alert);
    }



    public async Task<IEnumerable<AlertSummaryResponse>> GetAllAsync()
    {
        var alerts = await _alertRepository.GetAllAsync();

        return alerts.Select(a => new AlertSummaryResponse
        {
            Id = a.Id,
            CityId = a.CityId,
            WeatherType = a.WeatherType,
            Threshold = a.Threshold,
            IsActive = a.IsActive
        });
    }



    public async Task<AlertResponse?> GetByIdAsync(Guid id)
    {
        var alert = await _alertRepository.GetByIdAsync(id);

        if(alert == null)
        {
            return null;
        }


        return MapToResponse(alert);
    }



    public async Task DeleteAsync(Guid id)
    {
        var alert = await _alertRepository.GetByIdAsync(id);

        if(alert == null)
        {
            throw new InvalidOperationException(
                "Alert not found.");
        }


        await _alertRepository.DeleteAsync(alert);
    }



    private static AlertResponse MapToResponse(Alert alert)
    {
        return new AlertResponse
        {
            Id = alert.Id,
            CityId = alert.CityId,
            WeatherType = alert.WeatherType,
            Threshold = alert.Threshold,
            Email = alert.Email,
            IsActive = alert.IsActive,
            CreatedAt = alert.CreatedAt
        };
    }
}