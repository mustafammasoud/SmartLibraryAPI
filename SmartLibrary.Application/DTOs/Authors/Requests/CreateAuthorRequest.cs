using System.ComponentModel.DataAnnotations;

namespace SmartLibrary.Application.DTOs.Authors.Requests;

public class CreateAuthorRequest
{
    public  string Name { get; set; } = string.Empty;
}