﻿using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.DAL.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(256);
        builder.Property(b => b.Description)
            .IsRequired();
        builder.Property(b => b.CoverImageUrl)
            .IsRequired();
        builder.Property(b => b.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);
        builder.Property(b => b.ViewerCount)
            .HasDefaultValue(0);
        builder.HasOne(b => b.AppUser)
            .WithMany(u => u.Blogs)
            .HasForeignKey(b => b.AppUserId);
    }
}
