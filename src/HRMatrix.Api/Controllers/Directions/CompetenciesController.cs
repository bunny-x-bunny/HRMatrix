using HRMatrix.Application.DTOs.Competency;
using HRMatrix.Application.Services.Interfaces.Directions;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers.Directions;

[Route("api/[controller]")]
[ApiController]
public class CompetenciesController : ControllerBase
{
    private readonly ICompetencyService _competencyService;

    public CompetenciesController(ICompetencyService competencyService)
    {
        _competencyService = competencyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompetencies()
    {
        var competencies = await _competencyService.GetAllCompetenciesAsync();
        return Ok(competencies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompetencyById(int id)
    {
        var competency = await _competencyService.GetCompetencyByIdAsync(id);
        if (competency == null)
        {
            return NotFound();
        }
        return Ok(competency);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompetency([FromBody] CreateCompetencyDto competencyDto)
    {
        if (competencyDto == null)
        {
            return BadRequest("Invalid competency data.");
        }

        var createdCompetencyId = await _competencyService.CreateCompetencyAsync(competencyDto);
        return CreatedAtAction(nameof(GetCompetencyById), new { id = createdCompetencyId }, createdCompetencyId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCompetency([FromBody] UpdateCompetencyDto competencyDto)
    {
        if (competencyDto == null)
        {
            return BadRequest("Invalid competency data.");
        }

        var updatedCompetencyId = await _competencyService.UpdateCompetencyAsync(competencyDto);
        return Ok(updatedCompetencyId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompetency(int id)
    {
        var result = await _competencyService.DeleteCompetencyAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}