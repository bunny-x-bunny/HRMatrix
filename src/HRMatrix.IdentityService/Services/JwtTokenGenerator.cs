using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using HRMatrix.IdentityService.DTOs;
using HRMatrix.IdentityService.Models;
using Microsoft.IdentityModel.Tokens;

namespace HRMatrix.Application.Services
{
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
            var refreshToken = GenerateRefreshToken();

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

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
