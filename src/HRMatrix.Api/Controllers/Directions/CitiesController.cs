using HRMatrix.Application.DTOs.City;
using HRMatrix.Application.Services.Interfaces.Directions;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers.Directions;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly ICityService _cityService;

    public CitiesController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCities()
    {
        var cities = await _cityService.GetAllCitiesAsync();
        return Ok(cities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCityById(int id)
    {
        var city = await _cityService.GetCityByIdAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        return Ok(city);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCity([FromBody] CreateCityDto cityDto)
    {
        if (cityDto == null)
        {
            return BadRequest("Invalid city data.");
        }

        var createdCityId = await _cityService.CreateCityAsync(cityDto);
        return CreatedAtAction(nameof(GetCityById), new { id = createdCityId }, createdCityId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCity([FromBody] UpdateCityDto cityDto)
    {
        if (cityDto == null)
        {
            return BadRequest("Invalid city data.");
        }

        var updatedCityId = await _cityService.UpdateCityAsync(cityDto);
        return Ok(updatedCityId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCity(int id)
    {
        var result = await _cityService.DeleteCityAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}