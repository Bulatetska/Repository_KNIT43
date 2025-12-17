namespace indz
{
    public class Library
    {
        public List<Book> Books { get; set; } = new();
        public List<User> Users { get; set; } = new();

        public Library()
        {
            Populate();
        }

        void Populate()
        {
            Books.Add(new Book { Title = "Book 1", Author = "Author 1", YearPublished = 2001 });
            Books.Add(new Book { Title = "Book 2", Author = "Author 2", YearPublished = 2002 });
            Books.Add(new Book { Title = "Book 3", Author = "Author 3", YearPublished = 2003 });
            var book4 = new Book { Title = "Book 4", Author = "Author 4", YearPublished = 2004 };
            var book5 = new Book { Title = "Book 5", Author = "Author 5", YearPublished = 2005 };
            var book6 = new Book { Title = "Book 6", Author = "Author 6", YearPublished = 2006 };
            Books.Add(book4);
            Books.Add(book5);
            Books.Add(book6);

            var user1 = new User { Name = "User 1" };
            user1.AsIBorrower.Borrow(book4);
            user1.AsIBorrower.Borrow(book5);
            Users.Add(user1);
            Users.Add(new User { Name = "User 2" });
            var user3 = new User { Name = "User 3" };
            user3.AsIBorrower.Borrow(book6);
            Users.Add(user3);
        }

        public IEnumerable<Book> SearchBooks(string title, bool onlyFree = false)
        {
            var books = Books.AsEnumerable();
            if (onlyFree)
            {
                books = books.Where(book => book.Borrower == null);
            }
            title = title.ToLower();
            return books
                .Where(book => book.Title.ToLower().Contains(title))
                .OrderBy(book => (book.Author, book.Title));
        }

        public void BorrowBook(User user, Book book)
        {
            if (!Users.Contains(user))
            {
                throw new ArgumentException("User not in this Library");
            }

            user.AsIBorrower.Borrow(book);
        }

        public void ReturnBook(User user, Book book)
        {
            if (!Users.Contains(user))
            {
                throw new ArgumentException("User not in this Library");
            }

            user.AsIBorrower.Return(book);
        }
    }
}
