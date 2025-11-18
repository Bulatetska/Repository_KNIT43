public class Book
{
    // Первинний ключ (PK)
    public int Id { get; set; }
    public string? Title { get; set; }

    // Зовнішній ключ (FK)
    public int AuthorId { get; set; }

    // Навігаційна властивість "багато-до-одного"
    public Author Author { get; set; } = null!;
}