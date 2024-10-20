using AutoMapper;
using HRMatrix.Application.DTOs.UserAccount;
using HRMatrix.IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HRMatrix.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize] 
public class UserSurveyController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    private readonly IMapper _mapper;

    public UserSurveyController(UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _roleManager = roleManager;
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
        
        if (!string.IsNullOrEmpty(model.Role))
        {
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                    return BadRequest(removeResult.Errors);
            }
            
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                return BadRequest(new { message = "Role does not exist." });
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, model.Role);
            if (!addRoleResult.Succeeded)
                return BadRequest(addRoleResult.Errors);
        }

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
        
        if (!string.IsNullOrEmpty(model.Role))
        {
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                    return BadRequest(removeResult.Errors);
            }
            
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                return BadRequest(new { message = "Role does not exist." });
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, model.Role);
            if (!addRoleResult.Succeeded)
                return BadRequest(addRoleResult.Errors);
        }

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
            return Ok(new { message = "User account updated successfully" });

        return BadRequest(result.Errors);
    }

    [HttpGet("roles")]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleManager.Roles
            .Select(r => r.Name)
            .ToListAsync();

        if (roles == null || !roles.Any())
        {
            return NotFound("No roles found.");
        }

        return Ok(roles);
    }
}