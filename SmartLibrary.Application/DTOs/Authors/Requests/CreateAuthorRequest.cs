using System.ComponentModel.DataAnnotations;

namespace SmartLibrary.Application.DTOs.Authors.Requests;

public class CreateAuthorRequest
{
    [Required]
    [Range(1,50)]
    public  string Name { get; set; } = string.Empty;
}