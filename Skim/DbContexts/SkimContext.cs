using Microsoft.EntityFrameworkCore;
using Skim.Entities;

namespace Skim.DbContexts
{
    public class SkimContext : DbContext
    {
        public SkimContext(DbContextOptions<SkimContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Slug will have UNIQUE constraint
            builder.Entity<ShortLink>(entity => 
            {
                entity.HasIndex(e => e.Slug).IsUnique();
            });
        }

        public DbSet<ShortLink> ShortLinks { get; set; }
    }
}