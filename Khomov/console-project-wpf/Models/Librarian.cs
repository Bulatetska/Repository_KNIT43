namespace ConsoleProject.Models;

public class Librarian : Person
{
    public Librarian(string name) : base(name) { }

    public void AddItem(ConsoleProject.Services.Library library, ConsoleProject.Models.LibraryItem item)
        => library.AddItem(item);
}
