using AutoMapper;
using HRMatrix.Application.DTOs.UserAccount;
using HRMatrix.IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRMatrix.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize] 
public class UserSurveyController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public UserSurveyController(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetUserInfo()
    {
        var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

        if (string.IsNullOrEmpty(userName))
            return NotFound("User not found");

        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
            return NotFound("User not found");

        return Ok(new
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DateOfBirth = user.DateOfBirth,
            UserRole = userRole
        });
    }

    [HttpPatch("profile")]
    public async Task<IActionResult> UpdateUserInfo([FromBody] PatchUserAccountRequest model)
    {
        var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userName))
            return NotFound("User not found");

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return NotFound("User not found");
        
        _mapper.Map(model, user);

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
            return Ok(new { message = "User account updated successfully" });

        return BadRequest(result.Errors);
    }

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateFullUserInfo([FromBody] UpdateUserAccountRequest model)
    {
        var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userName))
            return NotFound("User not found");

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return NotFound("User not found");

        _mapper.Map(model, user);

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
            return Ok(new { message = "User account updated successfully" });

        return BadRequest(result.Errors);
    }
}