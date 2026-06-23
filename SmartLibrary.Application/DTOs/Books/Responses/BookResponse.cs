namespace SmartLibrary.Application.DTOs.Books.Responses;
public class BookResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string AuthorName { get; set; } = null!;
    public string? Description { get; set; }
    public int Year { get; set; }
}
