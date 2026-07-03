using Microsoft.AspNetCore.Mvc;
using SmartLibrary.Application.DTOs.Authors.Requests;
using SmartLibrary.Application.Interfaces;

namespace SmartLibrary.API.Controllers;

[ApiController]
[Route("/api/authors")]
public class AuthorController:ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatingAuthor(
                  [FromBody] CreateAuthorRequest request
                   ,[FromServices] IAuthorService service
                   , CancellationToken cn
                   )
    {
        var author = await service.CreateAsync(request,cn);
        return Created($"/api/authors/{author.Id}", author); 
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(IAuthorService service, CancellationToken cn )
    {
        return Ok(await service.GetAllAsync(cn));
    }


}