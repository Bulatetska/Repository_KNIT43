namespace ClassesLab;
public class BookGenre : Book
{
    public string Genre { get; set; }
    public BookGenre(string title, string author, decimal price, string genre)
        : base(title, author, price) => Genre = genre;
    public override void Print()
    { base.Print(); Console.WriteLine($"Жанр: {Genre}"); }
}
