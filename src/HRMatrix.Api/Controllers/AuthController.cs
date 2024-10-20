using HRMatrix.Application.Interfaces;
using HRMatrix.Application.Services;
using HRMatrix.IdentityService.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        var loginResult = await _authService.LoginAsync(loginDto);
        if (loginResult != null)
        {
            return Ok(new
            {
                AccessToken = loginResult.AccessToken,
                RefreshToken = loginResult.RefreshToken
            });
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

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
    {
        var refreshTokenResult = await _authService.RefreshTokenAsync(request);

        if (refreshTokenResult != null)
        {
            return Ok(new
            {
                AccessToken = refreshTokenResult.AccessToken,
                RefreshToken = refreshTokenResult.RefreshToken
            });
        }

        return Unauthorized(new { Message = "Invalid refresh token." });
    }
}
