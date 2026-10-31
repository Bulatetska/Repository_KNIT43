namespace ClassesLab;
public class Figure
{
    public string Name { get; set; }
    public Figure(string name) => Name = name;
    public virtual void Display() => Console.WriteLine($"Фігура: {Name}");
}
