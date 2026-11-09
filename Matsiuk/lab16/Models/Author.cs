namespace Lab16_EFCore.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string LastName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        // One author can have many books
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}