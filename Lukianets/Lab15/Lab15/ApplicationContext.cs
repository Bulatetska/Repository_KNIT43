using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    // DbSet для кожної сутності (таблиці). null! використовується для придушення попереджень C# про nullable-типи.
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;

    // Налаштування підключення до SQLite
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Використовуємо SQLite. Файл БД буде helloapp.db
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }

    // Використання HasData для автоматичного додавання початкових даних 
    // є більш чистою альтернативою, ніж додавання у Program.cs.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Додавання Авторів
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, FirstName = "Стівен", LastName = "Кінг" },
            new Author { Id = 2, FirstName = "Рей", LastName = "Бредбері" }
        );

        // Додавання Книг (через FK AuthorId)
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Сяйво", AuthorId = 1 },
            new Book { Id = 2, Title = "Воно", AuthorId = 1 },
            new Book { Id = 3, Title = "451° за Фаренгейтом", AuthorId = 2 },
            new Book { Id = 4, Title = "Марсіанські хроніки", AuthorId = 2 }
        );
    }
}