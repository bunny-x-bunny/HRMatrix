using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using HRMatrix.IdentityService.DTOs;
using HRMatrix.IdentityService.Models;
using Microsoft.IdentityModel.Tokens;

namespace HRMatrix.Application.Services;

public class JwtTokenGenerator
{
    public string Key { get; }
    private readonly string _issuer;
    private readonly string _audience;

    public JwtTokenGenerator(string key, string issuer, string audience)
    {
        Key = key;
        _issuer = issuer;
        _audience = audience;
    }

    public AuthResultDto GenerateTokens(ApplicationUser user, IEnumerable<string> userRoles)
    {
        var accessToken = GenerateAccessToken(user, userRoles);
        var refreshToken = GenerateRefreshToken(user);

        return new AuthResultDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    private string GenerateAccessToken(ApplicationUser user, IEnumerable<string> userRoles)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateRefreshToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                ///new Claim(ClaimTypes.NameIdentifier, user.Id)
            }),
            Expires = DateTime.UtcNow.AddDays(7), // Срок действия RefreshToken
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}