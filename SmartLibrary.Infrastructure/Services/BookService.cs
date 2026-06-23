using Microsoft.EntityFrameworkCore;
using SmartLibrary.Application.DTOs.Books.Requests;
using SmartLibrary.Application.DTOs.Books.Responses;
using SmartLibrary.Application.Interfaces;
using SmartLibrary.Infrastructure.Data;

namespace SmartLibrary.Infrastructure.Services;


public class BookService : IBookService
{

    private readonly AppDbContext _context ;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public  async Task<List<BookResponse>> GetAllAsync()
    {
        var books = await _context.Books
        .Select(b => new BookResponse
        {
           Id = b.Id,
           Title = b.Title,
           Year = b.Year,
           Description = b.Description,
           AuthorName = b.Author.Name
        }).ToListAsync();

        return books;
    }
}

