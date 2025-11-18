using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

// Використовуємо 'await using' для асинхронної утилізації контексту.
await RunDemo();

async Task RunDemo()
{
    Console.WriteLine("--- Підготовка БД та Запуск ---");

    // Створення контексту
    await using (var db = new ApplicationContext())
    {
        // 1. Застосування міграцій та додавання початкових даних (Data Seeding)
        // Цей метод застосує міграції та автоматично додасть дані, визначені у HasData.
        // Він також створить БД, якщо її немає.

        await db.Database.MigrateAsync();

        // 1. Створення об'єкта автора, який вже існує, або нового
        var newAuthor = new Author { FirstName = "Агата", LastName = "Крісті" };
        var newBook = new Book { Title = "Десять негренят", Author = newAuthor };

        // 2. Додавання та збереження нових об'єктів
        await db.Authors.AddAsync(newAuthor);
        await db.Books.AddAsync(newBook);

        await db.SaveChangesAsync(); // Записує нові дані в БД
        Console.WriteLine($"✅ Додано нового автора: {newAuthor.LastName}");

        // Якщо ви додаєте автора, який вже існує в HasData (Id = 1, 2), ви отримаєте помилку унікальності, 
        // тому краще додати НОВИЙ об'єкт або спочатку отримати існуючий об'єкт:

        var existingAuthor = await db.Authors.FirstOrDefaultAsync(a => a.LastName == "Кінг");
        if (existingAuthor != null)
        {
            var newKingBook = new Book { Title = "Зелена миля", Author = existingAuthor };
            await db.Books.AddAsync(newKingBook);
            await db.SaveChangesAsync();
            Console.WriteLine($"✅ Додано нову книгу до {existingAuthor.LastName}");
        }

        Console.WriteLine("✅ Структура БД оновлена, початкові дані додано.");


        // 2. Виведення даних (Read)
        Console.WriteLine("\n--- Список Книг з Авторами (Вибірка) ---");

        // LINQ запит з .Include() для завантаження пов'язаного об'єкта Author
        var booksWithAuthors = await db.Books
            .Include(b => b.Author) // Жадібне завантаження автора
            .OrderBy(b => b.Author.LastName)
            .ToListAsync();

        foreach (var book in booksWithAuthors)
        {
            Console.WriteLine($"- \"{book.Title}\" (Автор: {book.Author.FirstName} {book.Author.LastName})");
        }
    }
}