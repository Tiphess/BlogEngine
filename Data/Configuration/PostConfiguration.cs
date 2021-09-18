using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post", "dbo");

            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(p => p.PublicationDate)
                   .IsRequired();

            builder.Property(p => p.Content)
                   .IsRequired();

            builder.Property(p => p.CategoryId)
                   .IsRequired();

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Posts)
                   .HasForeignKey(p => p.CategoryId);
        }
    }
}
