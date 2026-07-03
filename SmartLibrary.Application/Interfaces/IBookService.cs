using SmartLibrary.Application.DTOs.Books.Responses;
using SmartLibrary.Application.DTOs.Books.Requests;


namespace SmartLibrary.Application.Interfaces;

public interface IBookService
{
    Task<List<BookResponse>> GetAllAsync(CancellationToken cn);
   // Task<BookResponse?> GetByIdAsync(Guid id);
    Task<BookResponse> AddAsync(CreateBookRequest request,CancellationToken cn);
}