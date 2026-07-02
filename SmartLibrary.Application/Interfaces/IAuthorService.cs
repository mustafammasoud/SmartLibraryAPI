using SmartLibrary.Application.DTOs.Authors.Requests;
using SmartLibrary.Application.DTOs.Authors.Responses;

namespace SmartLibrary.Application.Interfaces;

public interface IAuthorService
{
    Task<AuthorResponse> CreateAsync(CreateAuthorRequest request, CancellationToken ct = default);

    Task<List<AuthorResponse>> GetAllAsync(CancellationToken ct = default);
}

