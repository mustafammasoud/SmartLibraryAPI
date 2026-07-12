namespace SmartLibrary.Application.DTOs.Authentication.Jwt;

public class JwtTokenResponse
{
    public string AccessToken { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }
}