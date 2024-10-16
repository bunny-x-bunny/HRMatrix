using HRMatrix.Application.Interfaces;
using HRMatrix.IdentityService.DTOs;
using HRMatrix.IdentityService.Models;
using Microsoft.AspNetCore.Identity;

namespace HRMatrix.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
    {
        var user = new ApplicationUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
        }

        return result;
    }

    public async Task<string?> LoginAsync(LoginDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            var user = (await _userManager.FindByNameAsync(loginDto.Username))!;
            var roles = await _userManager.GetRolesAsync(user);

            return _jwtTokenGenerator.GenerateToken(user, roles);
        }

        return null;
    }
}
