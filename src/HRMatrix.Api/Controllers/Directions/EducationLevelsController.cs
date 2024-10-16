using HRMatrix.Application.DTOs.EducationLevel;
using HRMatrix.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers.Directions;

[Route("api/[controller]")]
[ApiController]
public class EducationLevelsController : ControllerBase
{
    private readonly IEducationLevelService _educationLevelService;

    public EducationLevelsController(IEducationLevelService educationLevelService)
    {
        _educationLevelService = educationLevelService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEducationLevels()
    {
        var educationLevels = await _educationLevelService.GetAllEducationLevelsAsync();
        return Ok(educationLevels);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEducationLevel(int id)
    {
        var educationLevel = await _educationLevelService.GetEducationLevelByIdAsync(id);
        if (educationLevel == null)
            return NotFound($"Education level with ID {id} not found.");

        return Ok(educationLevel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEducationLevel([FromBody] CreateEducationLevelDto educationLevelDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if (educationLevelDto.Translations == null || educationLevelDto.Translations.Count != 3) // TODO Пока что у нас данные на трех языках
            return BadRequest("Translations for three languages are required.");

        var createdEducationLevel = await _educationLevelService.CreateEducationLevelAsync(educationLevelDto);
        return CreatedAtAction(nameof(GetEducationLevel), new { id = createdEducationLevel.Id }, createdEducationLevel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEducationLevel(int id, [FromBody] UpdateEducationLevelDto educationLevelDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _educationLevelService.UpdateEducationLevelAsync(id, educationLevelDto);
        if (!updated)
            return NotFound($"Education level with ID {id} not found.");

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEducationLevel(int id)
    {
        var deleted = await _educationLevelService.DeleteEducationLevelAsync(id);
        if (!deleted)
            return NotFound($"Education level with ID {id} not found.");

        return NoContent();
    }
}
