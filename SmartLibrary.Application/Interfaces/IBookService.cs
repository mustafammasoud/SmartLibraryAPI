using SmartLibrary.Application.DTOs.Requests;
using SmartLibrary.Application.DTOs.Responses;

namespace SmartLibrary.Application.Interfaces;

public interface IBookService
{
    Task<List<BookResponse>> GetAllAsync();
    Task<BookResponse?> GetByIdAsync(Guid id);
    Task AddAsync(CreateBookRequest request);
}