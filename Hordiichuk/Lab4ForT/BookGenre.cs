// Lab4ForT/BookGenre.cs
namespace Lab4ForT
{
    public class BookGenre : Book
    {
        public string Genre { get; private set; }

        public BookGenre(string title, string author, int price, string genre)
            : base(title, author, price)
        {
            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentException("Genre не може бути порожнім.", nameof(genre));

            Genre = genre;
        }
    }
}
