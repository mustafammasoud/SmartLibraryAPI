namespace SmartLibrary.Application.DTOs.Responses;

public class BookResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? AuthorName { get; set; }
    public string? Description { get; set; }
    public int Year { get; set; }
}
