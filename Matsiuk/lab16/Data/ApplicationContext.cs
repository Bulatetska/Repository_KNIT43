using Microsoft.EntityFrameworkCore;
using Lab16_EFCore.Models;

namespace Lab16_EFCore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sqlite.db");
        }
    }
}