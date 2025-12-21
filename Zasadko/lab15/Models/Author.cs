using System.Collections.Generic;

namespace lab15.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new();
    }
}
