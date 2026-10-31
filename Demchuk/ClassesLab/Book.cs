namespace ClassesLab;
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public Book(string title, string author, decimal price)
    { Title = title; Author = author; Price = price; }
    public virtual void Print() => Console.WriteLine($"Книга: {Title}; Автор: {Author}; Ціна: {Price}");
}
