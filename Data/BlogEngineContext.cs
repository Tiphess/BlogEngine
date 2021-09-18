using Data.Configuration;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class BlogEngineContext : DbContext
    {
        public BlogEngineContext(DbContextOptions<BlogEngineContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
