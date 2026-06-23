using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLibrary.Domain.Entities;

namespace SmartLibrary.Infrastructure.Data.Config;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");

        builder.HasKey(x => x.Id);

        builder.Property(n => n.Name)
                        .IsRequired()
                        .HasMaxLength(50);
        builder.HasMany( b =>b.Books)
                .WithOne(a => a.Author)
                .HasForeignKey( f => f.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
