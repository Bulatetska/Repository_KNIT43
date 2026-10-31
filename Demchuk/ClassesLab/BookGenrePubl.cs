namespace ClassesLab;
public sealed class BookGenrePubl : BookGenre
{
    public string Publisher { get; set; }
    public BookGenrePubl(string title, string author, decimal price, string genre, string publisher)
        : base(title, author, price, genre) => Publisher = publisher;
    public override void Print()
    { base.Print(); Console.WriteLine($"Видавництво: {Publisher}"); }
}
