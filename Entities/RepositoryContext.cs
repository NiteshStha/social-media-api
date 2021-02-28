using System;
using Entities.models;
using Microsoft.EntityFrameworkCore;
using Utilities.Helpers;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new
            {
                UserId = 1,
                FirstName = "Nitesh",
                LastName = "Shrestha",
                Username = "nitesh",
                Password = PasswordHelper.HashPassword("123456"),
                DateOfBirth = DateTime.Now
            });
        }
    }
}