namespace SmartLibrary.Application.DTOs.Requests;

public class CreateBookRequest
{
    public  string? Title { get; set; }
    public  string? Description { get; set; }
    public  int Year { get; set; }
    public  Guid AuthorId { get; set; }
}