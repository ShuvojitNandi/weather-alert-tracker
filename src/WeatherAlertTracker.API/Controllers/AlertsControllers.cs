using Microsoft.AspNetCore.Mvc;
using WeatherAlertTracker.API.Helpers;
using WeatherAlertTracker.Application.DTOs.Alerts;
using WeatherAlertTracker.Application.Interfaces;

namespace WeatherAlertTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertsController : ControllerBase
{
    private readonly IAlertService _alertService;


    public AlertsController(IAlertService alertService)
    {
        _alertService = alertService;
    }



    // POST: api/alerts
    [HttpPost]
    public async Task<ActionResult<AlertResponse>> Create(
        CreateAlertRequest request)
    {
        var alert = await _alertService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = alert.Id },
            ApiResponseFactory.Success(
                alert,
                "Alert created successfully."));
    }



    // GET: api/alerts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlertSummaryResponse>>> GetAll()
    {
        var alerts = await _alertService.GetAllAsync();

        return Ok(
            ApiResponseFactory.Success(
                alerts,
                "Alerts retrieved successfully."));
    }



    // GET: api/alerts/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<AlertResponse>> GetById(Guid id)
    {
        var alert = await _alertService.GetByIdAsync(id);


        if(alert == null)
        {
            return NotFound(
                ApiResponseFactory.Error(
                    "Alert not found",
                    StatusCodes.Status404NotFound));
        }


        return Ok(
            ApiResponseFactory.Success(
                alert,
                "Alert retrieved successfully."));
    }



    // DELETE: api/alerts/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _alertService.DeleteAsync(id);

        return NoContent();
    }
}