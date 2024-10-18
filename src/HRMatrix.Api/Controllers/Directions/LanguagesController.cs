using HRMatrix.Application.DTOs.Languages;
using HRMatrix.Application.Services.Interfaces.Directions;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers.Directions;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService _languageService;

    public LanguagesController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLanguages()
    {
        var languages = await _languageService.GetAllLanguagesAsync();
        return Ok(languages);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLanguageById(int id)
    {
        var language = await _languageService.GetLanguageByIdAsync(id);
        if (language == null)
        {
            return NotFound();
        }
        return Ok(language);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLanguage([FromBody] CreateLanguageDto languageDto)
    {
        if (languageDto == null)
        {
            return BadRequest("Invalid language data.");
        }

        var createdLanguageId = await _languageService.CreateLanguageAsync(languageDto);
        return CreatedAtAction(nameof(GetLanguageById), new { id = createdLanguageId }, createdLanguageId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLanguage([FromBody] UpdateLanguageDto languageDto)
    {
        if (languageDto == null)
        {
            return BadRequest("Invalid language data.");
        }

        var updatedLanguageId = await _languageService.UpdateLanguageAsync(languageDto);
        return Ok(updatedLanguageId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLanguage(int id)
    {
        var result = await _languageService.DeleteLanguageAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
