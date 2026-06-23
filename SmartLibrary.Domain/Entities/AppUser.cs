namespace SmartLibrary.Domain.Entities;

public class AppUser
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public string? Email { get; set; }
}