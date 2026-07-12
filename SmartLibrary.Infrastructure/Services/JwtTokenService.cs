using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartLibrary.Application.DTOs.Authentication.Jwt;
using SmartLibrary.Application.Interfaces;

namespace SmartLibrary.Infrastructure.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration ;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(IEnumerable<Claim> claims)
    {
        var key = _configuration["JwtSettings:Key"]
                        ?? throw new InvalidOperationException("JWT Key is missing.");

        var securityKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(
                            securityKey,
                            SecurityAlgorithms.HmacSha256
                           );
       var token = new JwtSecurityToken
       (
        issuer:_configuration["JwtSettings:Issuer"],
        audience:_configuration["JwtSettings:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(
            Convert.ToDouble(_configuration["JwtSettings:ExpiryInMinutes"])
        ),
        signingCredentials:credentials
       );

       var jwt = new JwtSecurityTokenHandler().WriteToken(token);

      return jwt;
    }
}