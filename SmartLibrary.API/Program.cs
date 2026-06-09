using SmartLibrary.Application.Interfaces;
// using SmartLibrary.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

app.MapGet("/api", () => "Hello World");


app.Run();
