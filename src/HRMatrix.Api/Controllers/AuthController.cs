using HRMatrix.Application.Interfaces;
using HRMatrix.IdentityService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var token = await _authService.LoginAsync(loginDto);
        if (token != null)
        {
            return Ok(new { Token = token });
        }

        return Unauthorized(new { Message = "Invalid login attempt." });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);
        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(new { Message = "Registration failed." });
    }
}
