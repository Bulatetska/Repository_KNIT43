using indz;

var library = new Library();

List<string> SplitArgs(string text)
{
    List<string> args = new();

    string? currArg = "";
    bool quoted = false;
    bool backslash = false;
    foreach (var c in text)
    {
        if (backslash)
        {
            currArg = (currArg ?? "") + c;
            backslash = false;
            continue;
        }

        if (c == '\\')
        {
            backslash = true;
            continue;
        }

        if (c == '"')
        {
            currArg ??= "";
            quoted = !quoted;
            continue;
        }

        if (c == ' ')
        {
            if (!quoted)
            {
                if (currArg != null)
                {
                    args.Add(currArg);
                    currArg = null;
                }
                continue;
            }
        }

        currArg = (currArg ?? "") + c;
    }

    if (currArg != null)
    {
        args.Add(currArg);
    }

    return args;
}

while (true)
{
    Console.Write("> ");
    string? line = Console.ReadLine();
    if (line == null) break;

    var splitArgs = SplitArgs(line);
    switch (splitArgs[0])
    {
        case "help":
            if (splitArgs.Count > 1)
            {
                Console.WriteLine("Too many arguments");
                continue;
            }
            Console.WriteLine("users - list users");
            Console.WriteLine("search [<title>] - search for books");
            Console.WriteLine("searchfree [<title>] - search for free books");
            Console.WriteLine("borrow <user> <title> - borrow book");
            Console.WriteLine("return <user> <title> - return book");
            break;
        case "users":
            if (splitArgs.Count > 1)
            {
                Console.WriteLine("Too many arguments");
                continue;
            }
            Users();
            break;
        case "search":
            if (splitArgs.Count > 2)
            {
                Console.WriteLine("Too many arguments");
                continue;
            }
            Search(splitArgs.Count >= 2 ? splitArgs[1] : "", false);
            break;
        case "searchfree":
            if (splitArgs.Count > 2)
            {
                Console.WriteLine("Too many arguments");
                continue;
            }
            Search(splitArgs.Count >= 2 ? splitArgs[1] : "", true);
            break;
        case "borrow":
            if (splitArgs.Count != 3)
            {
                Console.WriteLine("Invalid number of arguments");
                continue;
            }
            BorrowBook(splitArgs[1], splitArgs[2]);
            break;
        case "return":
            if (splitArgs.Count != 3)
            {
                Console.WriteLine("Invalid number of arguments");
                continue;
            }
            ReturnBook(splitArgs[1], splitArgs[2]);
            break;
        default:
            Console.WriteLine("Unknown command, use \"help\" for help");
            break;
    }
}

void Users()
{
    foreach (var user in library.Users)
    {
        Console.WriteLine("Name: {0}", user.Name);
        Console.WriteLine("Borrowed Books: {0}", string.Join(", ", user.Borrowed.Select(x => x.Title)));
        Console.WriteLine();
    }
    Console.WriteLine();
}

void Search(string title, bool onlyFree)
{
    var books = library.SearchBooks(title, onlyFree);
    foreach (var book in books)
    {
        Console.WriteLine("Title: {0}", book.Title);
        Console.WriteLine("Author: {0}", book.Author);
        Console.WriteLine("YearPublished: {0}", book.YearPublished);
        if (book.Borrower != null)
        {
            Console.WriteLine("Borrowed by: {0}", book.Borrower.Name);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void BorrowBook(string userName, string bookTitle)
{
    User? user = library.Users.Find(x => x.Name == userName);
    if (user == null)
    {
        Console.WriteLine("User not found: {0}", userName);
        return;
    }
    Book? book = library.Books.Find(x => x.Title == bookTitle);
    if (book == null)
    {
        Console.WriteLine("Book not found: {0}", bookTitle);
        return;
    }
    if (book.Borrower != null)
    {
        Console.WriteLine("Book currently borrowed by {0}", book.Borrower.Name);
        return;
    }
    library.BorrowBook(user, book);
    Console.WriteLine("User {0} borrowed book {1}", user.Name, book.Title);
}

void ReturnBook(string userName, string bookTitle)
{
    User? user = library.Users.Find(x => x.Name == userName);
    if (user == null)
    {
        Console.WriteLine("User not found: {0}", userName);
        return;
    }
    Book? book = library.Books.Find(x => x.Title == bookTitle);
    if (book == null)
    {
        Console.WriteLine("Book not found: {0}", bookTitle);
        return;
    }
    if (book.Borrower != user)
    {
        Console.WriteLine("Book not borrowed by user");
        return;
    }
    library.ReturnBook(user, book);
    Console.WriteLine("User {0} returned book {1}", user.Name, book.Title);
}