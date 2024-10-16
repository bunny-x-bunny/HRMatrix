using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRMatrix.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize] 
public class UserSurveyController : ControllerBase
{
    [HttpGet("profile")]
    public IActionResult GetUserInfo()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

        if (string.IsNullOrEmpty(userId))
            return NotFound("User not found");

        return Ok(new
        {
            UserId = userId,
            UserRole = userRole
        });
    }
}