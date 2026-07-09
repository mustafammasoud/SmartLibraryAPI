using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartLibrary.API.ExceptionHandlers;
using SmartLibrary.Application.DTOs.Authors.Requests;
using SmartLibrary.Application.Interfaces;
using SmartLibrary.Infrastructure.Data;
using SmartLibrary.Infrastructure.Services;
// using SmartLibrary.Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(Options =>
{
    Options.DefaultAuthenticateScheme =
                 CookieAuthenticationDefaults.AuthenticationScheme;

    Options.DefaultChallengeScheme = 
                 CookieAuthenticationDefaults.AuthenticationScheme;

    Options.DefaultForbidScheme =
                 CookieAuthenticationDefaults.AuthenticationScheme;
    
}).AddCookie(Options =>
{
    Options.LoginPath = "/login";
    Options.AccessDeniedPath = "/access-denied";

    Options.Cookie.HttpOnly = true;

    Options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

    Options.Cookie.SameSite = SameSiteMode.Lax;
});



builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAuthorRequest>();
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = (context) =>
    {
        context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
        context.ProblemDetails.Extensions.Add("requestId",context.HttpContext.TraceIdentifier);
    };
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IAuthorService , AuthorService>();

builder.Services.AddDbContext<AppDbContext>(
 options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);


var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// app.MapGet("/api/books", async(IBookService service) =>
// {
//     return await service.GetAllAsync();
// });

// app.MapPost("/api/authors",async (CreateAuthorRequest request, IAuthorService service,CancellationToken ct ) =>
// {
//     var author = await service.CreateAsync(request,ct);

//     return Results.Created($"/api/authors/{author.Id}", author);
// }
// );

// app.MapGet("/api/authors" , async (IAuthorService service , CancellationToken ct) =>
// {
//     return Results.Ok (await service.GetAllAsync(ct));
// });

app.Run();
