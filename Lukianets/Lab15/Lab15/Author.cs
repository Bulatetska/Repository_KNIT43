using System.Collections.Generic;

public class Author
{
    // Первинний ключ (PK)
    public int Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }

    // Навігаційна властивість "один-до-багатьох": список книг
    public List<Book> Books { get; set; } = new List<Book>();
}