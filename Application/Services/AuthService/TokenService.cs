﻿using Domain.Entities.Catalog;
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

        //public string GenerateJwtToken(ApplicationUser user)
        //{
        //    var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //        new Claim(ClaimTypes.Name, user.FullName),
        //        new Claim(ClaimTypes.Email,user.Email),
        //        new Claim(ClaimTypes.Role,user.Role.ToLower()),
        //    };

        //    var token = new JwtSecurityToken
        //        (
        //        //_configuration["Jwt:Issuer"],
        //        //_configuration["Jwt:Audience"],
        //        claims:claims,
        //        signingCredentials: Credentials,
        //        expires: DateTime.UtcNow.AddHours(1)
        //        );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        public string GenerateJwtToken(ApplicationUser user)
        {
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
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}