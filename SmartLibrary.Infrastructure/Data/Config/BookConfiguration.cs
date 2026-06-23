using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLibrary.Domain.Entities;

namespace SmartLibrary.Infrastructure.Data.Config;


public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(b => b.Id);

        builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

        builder.Property(d => d.Description)
                .IsRequired(false)
                .HasMaxLength(1000);

        builder.Property(y => y.Year)
                .IsRequired();
        
       builder.HasOne(a => a.Author)
               .WithMany(b => b.Books)
               .HasForeignKey(f => f.AuthorId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
