using Microsoft.EntityFrameworkCore;
using SmartLibrary.Application.DTOs.Books.Requests;
using SmartLibrary.Application.DTOs.Books.Responses;
using SmartLibrary.Application.Interfaces;
using SmartLibrary.Domain.Entities;
using SmartLibrary.Infrastructure.Data;

namespace SmartLibrary.Infrastructure.Services;


public class BookService : IBookService
{

    private readonly AppDbContext _context ;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<BookResponse> AddAsync(CreateBookRequest request, CancellationToken ct)
    {
        var book =  new Book
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            AuthorId = request.AuthorId,
            Year = request.Year
        };

       var author = await _context
                         .Authors
                         .FirstOrDefaultAsync(a => a.Id == request.AuthorId ,ct);
                    
        if(author is null)
        {
            throw new KeyNotFoundException("Author Not Found");
        }
        await _context.Books.AddAsync(book,ct);
        await _context.SaveChangesAsync(ct);

        return new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            AuthorName = author.Name,
            Year = book.Year
        };

    }

    public  async Task<List<BookResponse>> GetAllAsync(CancellationToken cn)
    {
        var books = await _context.Books
        .Select(b => new BookResponse
        {
           Id = b.Id,
           Title = b.Title,
           Year = b.Year,
           Description = b.Description,
           AuthorName = b.Author.Name
        }).ToListAsync(cn);

        return books;
    }

    
}

