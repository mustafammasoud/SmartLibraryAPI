using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLibrary.Domain.Entities;

namespace SmartLibrary.Infrastructure.Data.Config;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(k => k.Id);

        builder.Property(n => n.FullName)
                        .IsRequired()
                        .HasMaxLength(50);

        builder.Property(e => e.Email)
                        .HasMaxLength(150);
    }
}

