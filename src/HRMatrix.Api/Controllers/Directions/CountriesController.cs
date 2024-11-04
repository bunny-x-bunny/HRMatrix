using HRMatrix.Application.DTOs.Country;
using HRMatrix.Application.DTOs;
using HRMatrix.Application.Services.Interfaces.Directions;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers.Directions;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountriesController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCountries()
    {
        var countries = await _countryService.GetAllCountriesAsync();
        return Ok(countries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCountryById(int id)
    {
        var country = await _countryService.GetCountryByIdAsync(id);
        if (country == null)
        {
            return NotFound();
        }
        return Ok(country);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDto countryDto)
    {
        if (countryDto == null)
        {
            return BadRequest("Invalid country data.");
        }

        var createdCountryId = await _countryService.CreateCountryAsync(countryDto);
        return CreatedAtAction(nameof(GetCountryById), new { id = createdCountryId }, createdCountryId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryDto countryDto)
    {
        if (countryDto == null)
        {
            return BadRequest("Invalid country data.");
        }

        var updatedCountryId = await _countryService.UpdateCountryAsync(countryDto);
        return Ok(updatedCountryId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        var result = await _countryService.DeleteCountryAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}