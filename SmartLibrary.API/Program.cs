using Microsoft.EntityFrameworkCore;
using SmartLibrary.Application.Interfaces;
using SmartLibrary.Infrastructure.Data;
// using SmartLibrary.Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(
 options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

app.MapGet("/api", () => "Hello World");


app.Run();
