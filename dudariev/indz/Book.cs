using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace indz
{
    public class Book : IBorrowable<Book, User>, INotifyPropertyChanged
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required int YearPublished { get; set; }

        public IBorrowable<Book, User> AsIBorrowable { get => this; }
        private User? _Borower = null;
        public User? Borrower
        {
            get => _Borower;
            set
            {
                _Borower = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
