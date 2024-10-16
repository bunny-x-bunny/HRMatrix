using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileEducationController : ControllerBase
{
    private readonly IUserProfileEducationService _userProfileEducationService;

    public UserProfileEducationController(IUserProfileEducationService userProfileEducationService)
    {
        _userProfileEducationService = userProfileEducationService;
    }
    
    [HttpGet("{userProfileId}")]
    public async Task<IActionResult> GetUserProfileEducations(int userProfileId)
    {
        var userProfileEducations = await _userProfileEducationService.GetUserProfileEducationsAsync(userProfileId);

        if (userProfileEducations == null)
        {
            return NotFound($"User profile with ID {userProfileId} not found or no education data.");
        }

        return Ok(userProfileEducations);
    }
    
    [HttpPost("single")]
    public async Task<IActionResult> CreateUserProfileEducation([FromBody] CreateUserProfileEducationRequest educationRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdEducation = await _userProfileEducationService.CreateUserProfileEducationAsync(educationRequest);
            return CreatedAtAction(nameof(GetUserProfileEducations), new { userProfileId = educationRequest.UserProfileId }, createdEducation);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
    
    [HttpPost("multiple")]
    public async Task<IActionResult> CreateUserProfileEducations([FromBody] CreateMultipleUserProfileEducationRequest educationRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdEducations = await _userProfileEducationService.CreateUserProfileEducationsAsync(educationRequest.UserProfileId, educationRequest.Educations);
            return CreatedAtAction(nameof(GetUserProfileEducations), new { userProfileId = educationRequest.UserProfileId }, createdEducations);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> UpdateUserProfileEducations([FromBody] UpdateUserProfileEducationRequest updateRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedEducations = await _userProfileEducationService.UpdateUserProfileEducationsAsync(updateRequest);
            return Ok(updatedEducations);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
