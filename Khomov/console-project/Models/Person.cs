namespace ConsoleProject.Models;

public abstract class Person : ConsoleProject.Interfaces.IIdentifiable
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }

    protected Person(string name) => Name = name;

    public override string ToString() => Name;
}
