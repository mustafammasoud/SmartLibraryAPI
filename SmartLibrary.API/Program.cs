using Microsoft.EntityFrameworkCore;
using SmartLibrary.Application.DTOs.Authors.Requests;
using SmartLibrary.Application.Interfaces;
using SmartLibrary.Infrastructure.Data;
using SmartLibrary.Infrastructure.Services;
// using SmartLibrary.Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IAuthorService , AuthorService>();

builder.Services.AddDbContext<AppDbContext>(
 options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);


var app = builder.Build();

app.MapControllers();

app.MapGet("/api/books", async(IBookService service) =>
{
    return await service.GetAllAsync();
});

// app.MapPost("/api/authors",async (CreateAuthorRequest request, IAuthorService service,CancellationToken ct ) =>
// {
//     var author = await service.CreateAsync(request,ct);

//     return Results.Created($"/api/authors/{author.Id}", author);
// }
// );

app.MapGet("/api/authors" , async (IAuthorService service , CancellationToken ct) =>
{
    return Results.Ok (await service.GetAllAsync(ct));
});

app.Run();
