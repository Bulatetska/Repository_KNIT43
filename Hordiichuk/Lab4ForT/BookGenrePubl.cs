// Lab4ForT/BookGenrePubl.cs
namespace Lab4ForT
{
    public class BookGenrePubl : BookGenre
    {
        public string Publisher { get; private set; }

        public BookGenrePubl(string title, string author, int price, string genre, string publisher)
            : base(title, author, price, genre)
        {
            if (string.IsNullOrWhiteSpace(publisher))
                throw new ArgumentException("Publisher не може бути порожнім.", nameof(publisher));

            Publisher = publisher;
        }
    }
}
