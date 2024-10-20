using HRMatrix.IdentityService.DTOs;
using Microsoft.AspNetCore.Identity;

namespace HRMatrix.Application.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        Task<AuthResultDto> LoginAsync(LoginDto loginDto);
        Task<AuthResultDto> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
