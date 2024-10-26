using HRMatrix.Application.DTOs.Specialization;
using HRMatrix.Application.Services.Interfaces.Directions;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers.Directions;

[Route("api/[controller]")]
[ApiController]
public class SpecializationsController : ControllerBase
{
    private readonly ISpecializationService _specializationService;

    public SpecializationsController(ISpecializationService specializationService)
    {
        _specializationService = specializationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSpecializations()
    {
        var specializations = await _specializationService.GetAllSpecializationsAsync();
        return Ok(specializations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpecializationById(int id)
    {
        var specialization = await _specializationService.GetSpecializationByIdAsync(id);
        if (specialization == null)
        {
            return NotFound();
        }
        return Ok(specialization);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpecialization([FromBody] CreateSpecializationDto specializationDto)
    {
        if (specializationDto == null)
        {
            return BadRequest("Invalid specialization data.");
        }

        var createdSpecializationId = await _specializationService.CreateSpecializationAsync(specializationDto);
        return CreatedAtAction(nameof(GetSpecializationById), new { id = createdSpecializationId }, createdSpecializationId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSpecialization([FromBody] UpdateSpecializationDto specializationDto)
    {
        if (specializationDto == null)
        {
            return BadRequest("Invalid specialization data.");
        }

        var updatedSpecializationId = await _specializationService.UpdateSpecializationAsync(specializationDto);
        return Ok(updatedSpecializationId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpecialization(int id)
    {
        var result = await _specializationService.DeleteSpecializationAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}