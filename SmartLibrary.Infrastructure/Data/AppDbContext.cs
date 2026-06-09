using Microsoft.EntityFrameworkCore;
using SmartLibrary.Domain.Entities;

namespace SmartLibrary.Infrastructure.Data;

public class AppDbContext : DbContext
{
  public  AppDbContext(DbContextOptions<AppDbContext> options)  : base(options)
    {
    } 

    public DbSet<Book> Books {get; set;}
    public DbSet<Author> Authors {get; set;}
    public DbSet<AppUser> Users {get; set;}
}

