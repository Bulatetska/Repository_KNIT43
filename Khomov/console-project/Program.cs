using ConsoleProject.Models;
using ConsoleProject.Services;

namespace ConsoleProject;

internal class Program
{
    private static void Main()
    {
        var library = new Library();

        var librarian = new Librarian("Anna");
        var memberRoman = new Member("Roman");
        var memberDenys = new Member("Denys");

        library.RegisterMember(memberRoman);
        library.RegisterMember(memberDenys);

        librarian.AddItem(library, new Book("Clean Code", "Robert C. Martin", 2008));
        librarian.AddItem(library, new Magazine("National Geographic", 202, 2024));
        librarian.AddItem(library, new Dvd("Interstellar", 169, 2014));

        Console.WriteLine("All items in library:");
        foreach (var item in library.Items) {
            Console.WriteLine($" - {item} (Id: {item.Id})");
        }

        var firstItem = library.Items.First();
        Console.WriteLine($"\n{memberRoman.Name} tries to borrow '{firstItem.Title}':");
        if (library.BorrowItem(firstItem.Id, memberRoman.Id)) {
            Console.WriteLine("Borrowed successfully!");
        }
        else {
            Console.WriteLine("Failed to borrow.");
        }

        Console.WriteLine($"\n{memberDenys.Name} tries to borrow the same item:");
        if (!library.BorrowItem(firstItem.Id, memberDenys.Id)) {
            Console.WriteLine("Item is already borrowed – cannot borrow.");
        }

        Console.WriteLine("\nReturning item...");
        library.ReturnItem(firstItem.Id);

        Console.WriteLine("Now borrowing again:");
        if (library.BorrowItem(firstItem.Id, memberDenys.Id)) {
            Console.WriteLine("Borrowed successfully by Denys!");
        }

        Console.WriteLine("\nSearch results for 'Clean':");
        foreach (var result in library.Search("Clean")) {
            Console.WriteLine(result);
        }
    }
}
