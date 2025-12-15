using System.Collections.Generic;

public class Author
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;

    // Навігаційна властивість — один автор має багато книг
    public List<Book> Books { get; set; } = new();
}
