using Microsoft.EntityFrameworkCore;
using SmartLibrary.Application.Interfaces;
using SmartLibrary.Infrastructure.Data;
using SmartLibrary.Infrastructure.Services;
// using SmartLibrary.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBookService,BookService>();

builder.Services.AddDbContext<AppDbContext>(
 options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);


var app = builder.Build();

app.MapGet("/api/books", async(IBookService service) =>
{
    return await service.GetAllAsync();
});


app.Run();
