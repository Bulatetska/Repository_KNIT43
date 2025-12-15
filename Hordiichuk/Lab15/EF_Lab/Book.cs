public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    // Зовнішній ключ
    public int AuthorId { get; set; }

    // Навігаційна властивість
    public Author Author { get; set; } = null!;
}
