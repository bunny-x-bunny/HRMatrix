using HRMatrix.Application.DTOs.UserProfileCompetency;
using HRMatrix.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileCompetenciesController : ControllerBase
{
    private readonly IUserProfileCompetencyService _userProfileCompetencyService;

    public UserProfileCompetenciesController(IUserProfileCompetencyService userProfileCompetencyService)
    {
        _userProfileCompetencyService = userProfileCompetencyService;
    }

    [HttpGet("{userProfileId}")]
    public async Task<IActionResult> GetUserProfileCompetencies(int userProfileId)
    {
        var competencies = await _userProfileCompetencyService.GetUserProfileCompetenciesAsync(userProfileId);
        return Ok(competencies);
    }

    [HttpPost]
    public async Task<IActionResult> UpsertUserProfileCompetencies([FromBody] CreateUserProfileCompetenciesRequest competenciesRequest)
    {
        var userProfileId = await _userProfileCompetencyService.UpsertUserProfileCompetenciesAsync(competenciesRequest, true);
        return Ok(userProfileId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserProfileCompetency(int id)
    {
        var result = await _userProfileCompetencyService.DeleteUserProfileCompetencyAsync(id, true);
        return result ? NoContent() : NotFound();
    }
}