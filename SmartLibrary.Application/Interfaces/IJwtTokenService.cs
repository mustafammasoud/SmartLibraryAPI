using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace SmartLibrary.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(IEnumerable<Claim> claims);
}