using SmartLibrary.Application.DTOs.Books.Responses;
using SmartLibrary.Application.DTOs.Books.Requests;


namespace SmartLibrary.Application.Interfaces;

public interface IBookService
{
    Task<List<BookResponse>> GetAllAsync();
   // Task<BookResponse?> GetByIdAsync(Guid id);
    //Task AddAsync(CreateBookRequest request);
}