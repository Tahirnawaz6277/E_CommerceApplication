using Domain.Entities.Catalog;
using E_Commerce.Application.Interfaces.IService.IAuthService;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Commerce.Application.Services.AuthService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(ApplicationUser user)
        {
            var jwtsettings = _configuration.GetSection("Jwt");
            var tokenExpiry = jwtsettings.GetValue<int>("TokenExpiry");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToLower())  // Make sure role is lowercase
            };

            var token = new JwtSecurityToken(
                //_configuration["Jwt:Issuer"],
               //_configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(tokenExpiry),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}