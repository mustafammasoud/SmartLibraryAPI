using System.ComponentModel.DataAnnotations;
using SmartLibrary.Application.Validators;
namespace SmartLibrary.Application.DTOs.Books.Requests;

public class CreateBookRequest
{
  
    public required string Title { get; set; }
    public  string? Description { get; set; }
    public  int Year { get; set; }
    public  Guid AuthorId { get; set; }
}
