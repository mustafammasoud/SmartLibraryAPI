using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using LoginRequest = SmartLibrary.Application.DTOs.Authentication.Requests.LoginRequest;
namespace SmartLibrary.API.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController:ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if(request.Username != "admin" || request.Password != "12345")
            return Unauthorized();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Name, "admin"),
            new Claim(ClaimTypes.Email, "admin@smartlibrary.com"),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme
        );

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal
        );
        return Ok(
            new
            {
                Message = "Login Success"
            }
        );
    }

    [HttpPost("logout")]

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme
        );

        return Ok(
            new
            {
                Message = "Logged out successfully"
            }
        );
    }

    [HttpGet("me")]
   public IActionResult Me()
    {
        return Ok(new
{
                IsAuthenticated = User.Identity?.IsAuthenticated,
                Username = User.Identity?.Name,
                Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Email = User.FindFirst(ClaimTypes.Email)?.Value,
                Role= User.FindFirst(ClaimTypes.Role)?.Value
             });
    }

}