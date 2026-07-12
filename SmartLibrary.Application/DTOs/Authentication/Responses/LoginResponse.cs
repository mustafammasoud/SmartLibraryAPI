namespace SmartLibrary.Application.DTOs.Authentication.Responses;


public class LoginResponse
{
    public string Token {get; set;} = string.Empty;

    public DateTime ExpiresAt {get; set;}
}