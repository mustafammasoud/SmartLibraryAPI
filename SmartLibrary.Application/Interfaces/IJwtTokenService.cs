using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using SmartLibrary.Application.DTOs.Authentication.Jwt;

namespace SmartLibrary.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(IEnumerable<Claim> claims);
}