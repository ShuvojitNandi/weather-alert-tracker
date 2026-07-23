using Microsoft.AspNetCore.Mvc;
using WeatherAlertTracker.Application.DTOs.Cities;
using WeatherAlertTracker.Application.DTOs.Forecast;
using WeatherAlertTracker.Application.Interfaces;
using WeatherAlertTracker.API.Helpers;
using WeatherAlertTracker.Application.Services;

namespace WeatherAlertTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ICityService _cityService;
    private readonly ForecastService _forecastService;


    public CitiesController(ICityService cityService, ForecastService forecastService)
    {
        _cityService = cityService;
        _forecastService = forecastService;
    }


    // POST: api/cities
    [HttpPost]
    public async Task<ActionResult<CityResponse>> Create(
        CreateCityRequest request)
    {
        var city = await _cityService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = city.Id },
            ApiResponseFactory.Success(
                city,
                "City created successfully."));
    }



    // GET: api/cities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CitySummaryResponse>>> GetAll()
    {
        var cities = await _cityService.GetAllAsync();

        return Ok(
            ApiResponseFactory.Success(
                cities,
                "Cities retrieved successfully."));
    }



    // GET: api/cities/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<CityResponse>> GetById(Guid id)
    {
        var city = await _cityService.GetByIdAsync(id);


        if(city == null)
        {
            return NotFound();
        }


        return Ok(
            ApiResponseFactory.Success(
                city,
                "City retrieved successfully."));
    }



    // GET: api/cities/{id}/forecast
    [HttpGet("{id}/forecast")]
    public async Task<ActionResult<ForecastResponse>> GetForecast(Guid id)
    {
        var forecast = await _forecastService.GetForecastAsync(id);

        if (forecast is null)
        {
            return NotFound(
                ApiResponseFactory.Error(
                    "City not found",
                    StatusCodes.Status404NotFound));
        }

        return Ok(
            ApiResponseFactory.Success(
                forecast,
                "Forecast retrieved successfully."));
    }


    // DELETE: api/cities/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _cityService.DeleteAsync(id);

        return NoContent();
    }

    
}