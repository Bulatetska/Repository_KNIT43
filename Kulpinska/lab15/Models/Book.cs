namespace EfCoreLab.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public int AuthorId { get; set; }
        public required Author Author { get; set; }
    }
}
