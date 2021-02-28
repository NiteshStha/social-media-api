using Entities.models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<User> Types { get; set; }
        public DbSet<Post> TechnicalMachines { get; set; }
        public DbSet<Comment> Moves { get; set; }
    }
}