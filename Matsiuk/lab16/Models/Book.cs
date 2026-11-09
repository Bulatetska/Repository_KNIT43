namespace Lab16_EFCore.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        // Foreign Key
        public int AuthorId { get; set; }

        // Navigation property
        public Author Author { get; set; } = null!;
    }
}