// Lab4ForT/Book.cs
namespace Lab4ForT
{
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Price { get; private set; }

        public Book(string title, string author, int price)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title не може бути порожнім.", nameof(title));
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author не може бути порожнім.", nameof(author));
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price не може бути від’ємним.");

            Title = title;
            Author = author;
            Price = price;
        }
    }
}
