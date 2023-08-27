using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.DAL.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(c => c.Surname)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(c => c.ImageUrl)
            .IsRequired(false);
    }
}
