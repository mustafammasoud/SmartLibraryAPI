using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SmartLibrary.Domain.Entities;

namespace SmartLibrary.Infrastructure.Data;

public class AppDbContext : DbContext
{
  public  AppDbContext(DbContextOptions<AppDbContext> options)  : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    public DbSet<Book> Books {get; set;}
    public DbSet<Author> Authors {get; set;}
    public DbSet<AppUser> Users {get; set;}
}

