using Microsoft.EntityFrameworkCore;

namespace HowAreYou.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        
        public ApplicationDbContext(): base()
        { 
            // This space intentionally left blank
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasIndex(p => p.Number).IsUnique();
        }
    }
}