using System.ComponentModel.DataAnnotations;
using SmartLibrary.Application.Validators;
namespace SmartLibrary.Application.DTOs.Books.Requests;

public class CreateBookRequest
{
    [Required]
    [Range(1,50)]
    public required string Title { get; set; }

    [Range(1,1000)]
    public  string? Description { get; set; }

    [MaxCurrentYear]
    public  int Year { get; set; }
    public  Guid AuthorId { get; set; }
}
