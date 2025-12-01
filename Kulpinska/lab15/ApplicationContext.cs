using Microsoft.EntityFrameworkCore;
using EfCoreLab.Models;

namespace EfCoreLab
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=library.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .HasOne(b => b.Author)
                        .WithMany(a => a.Books)
                        .HasForeignKey(b => b.AuthorId);
        }
    }
}
