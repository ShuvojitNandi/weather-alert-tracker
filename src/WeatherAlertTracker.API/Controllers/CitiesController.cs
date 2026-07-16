using Microsoft.AspNetCore.Mvc;
using WeatherAlertTracker.Application.DTOs.Cities;
using WeatherAlertTracker.Application.Interfaces;

namespace WeatherAlertTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ICityService _cityService;


    public CitiesController(ICityService cityService)
    {
        _cityService = cityService;
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
            city);
    }



    // GET: api/cities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CitySummaryResponse>>> GetAll()
    {
        var cities = await _cityService.GetAllAsync();

        return Ok(cities);
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


        return Ok(city);
    }



    // DELETE: api/cities/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _cityService.DeleteAsync(id);

        return NoContent();
    }
}