using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLibrary.Application.DTOs.Authors.Requests;
using SmartLibrary.Application.DTOs.Authors.Responses;
using SmartLibrary.Application.Interfaces;
using SmartLibrary.Domain.Entities;
using SmartLibrary.Infrastructure.Data;

namespace SmartLibrary.Infrastructure.Services;

public class AuthorService : IAuthorService
{

    private readonly AppDbContext _context;

    public AuthorService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<AuthorResponse> CreateAsync(CreateAuthorRequest request , CancellationToken ct)
    {
        var author = new Author
        {
            Id  = Guid.NewGuid(),
            Name = request.Name
        };

        await _context.Authors.AddAsync(author,ct);
        await _context.SaveChangesAsync(ct);

        return new AuthorResponse
        {
            Id = author.Id,
            Name = author.Name
        };

    }

    public Task<List<AuthorResponse>> GetAllAsync(CancellationToken ct)
    {
        return _context.Authors
                    .Select (author => new AuthorResponse
                    {
                        Id = author.Id,
                        Name = author.Name
                    }
                    ).ToListAsync(ct);
    }

}