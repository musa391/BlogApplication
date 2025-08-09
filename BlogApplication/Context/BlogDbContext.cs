using Microsoft.EntityFrameworkCore;
using BlogApplication.Models;

namespace BlogApplication.Context
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Kullanici> Kullanicis { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7TSL0VJ\\SQLEXPRESS;Database=BlogDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
