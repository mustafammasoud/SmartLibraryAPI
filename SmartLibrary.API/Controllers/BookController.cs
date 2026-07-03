using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using SmartLibrary.Application.DTOs.Books.Requests;
using SmartLibrary.Application.Interfaces;

namespace SmartLibrary.API.Controllers;

[ApiController]
[Route("/api/books")]
public class BookController:ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBook(
            [FromBody]CreateBookRequest request , [FromServices]IBookService service,
            CancellationToken ct
                                )
    {
        var book = await service.AddAsync(request,ct);
        return Created($"/api/books/{book.Id}",book);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(IBookService service , CancellationToken cn)
    {
        var books = await service.GetAllAsync(cn);
        if (!books.Any())
        {
            return Problem (
             type:"https://example.com/errors/not-found",
             title:"Books Not Found",
             statusCode: StatusCodes.Status404NotFound,
             detail:"There is no Books in here",
             instance:"/api/books"
           );
        }
        return Ok(books);
    }
}

