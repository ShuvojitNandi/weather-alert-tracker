using WeatherAlertTracker.Application.DTOs.Cities;
using WeatherAlertTracker.Application.Interfaces;
using WeatherAlertTracker.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace WeatherAlertTracker.Application.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    private readonly ILogger<CityService> _logger;


    public CityService(ICityRepository cityRepository,ILogger<CityService> logger)
    {
        _cityRepository = cityRepository;
        _logger = logger;
    }


    public async Task<CityResponse> CreateAsync(CreateCityRequest request)
    {
        _logger.LogInformation(
            "Creating city {CityName}",
            request.Name);

        var city = new City
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Province = request.Province,
            Country = request.Country,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            CreatedAt = DateTime.UtcNow
        };


        await _cityRepository.AddAsync(city);

        _logger.LogInformation(
            "City created successfully. CityId: {CityId}",
            city.Id);


        return MapToResponse(city);
    }


    public async Task<IEnumerable<CitySummaryResponse>> GetAllAsync()
    {
        var cities = await _cityRepository.GetAllAsync();


        return cities.Select(city => new CitySummaryResponse
        {
            Id = city.Id,
            Name = city.Name,
            Province = city.Province
        });
    }


    public async Task<CityResponse?> GetByIdAsync(Guid id)
    {
        var city = await _cityRepository.GetByIdAsync(id);


        if(city == null)
            return null;


        return MapToResponse(city);
    }


    public async Task DeleteAsync(Guid id)
    {
        var city = await _cityRepository.GetByIdAsync(id);


        if(city == null)
            throw new KeyNotFoundException("City not found");


        await _cityRepository.DeleteAsync(city);
    }



    private static CityResponse MapToResponse(City city)
    {
        return new CityResponse
        {
            Id = city.Id,
            Name = city.Name,
            Province = city.Province,
            Country = city.Country,
            Latitude = city.Latitude,
            Longitude = city.Longitude,
            CreatedAt = city.CreatedAt
        };
    }
}