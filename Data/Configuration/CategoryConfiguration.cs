using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "dbo");

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasMany(c => c.Posts)
                   .WithOne(p => p.Category);
        }
    }
}
