using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace lab10
{
    internal class BookViewModel : INotifyPropertyChanged
    {
        private Book? selectedBook;
        public ObservableCollection<Book> Books { get; } = [];

        private ICommand? addBookCommand;
        public ICommand AddBookCommand
        {
            get => addBookCommand ??= new RelayCommand(_ =>
            {
                var book = new Book { Title = "Title", Author = "Author", Year = 2025 };
                Books.Add(book);
                SelectedBook = book;
                OnBookAdded?.Invoke(null, new EventArgs());
            });
        }

        private ICommand? removeBookCommand;
        public ICommand RemoveBookCommand
        {
            get => removeBookCommand ??= new RelayCommand(
                _ =>
                {
                    if (SelectedBook != null)
                    {
                        int index = Books.IndexOf(SelectedBook);
                        if (index >= 0) Books.RemoveAt(index);
                        SelectedBook = Books.ElementAtOrDefault(Math.Min(index, Books.Count - 1));
                    }
                },
                _ => SelectedBook != null
            );
        }

        public event EventHandler? OnBookAdded;

        public Book? SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
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
