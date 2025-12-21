using lab10.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace lab10.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Book> Books { get; } = new();

        private Book? selectedBook;
        public Book? SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        public ICommand AddBookCommand { get; }
        public ICommand DeleteBookCommand { get; }

        public BookViewModel()
        {
            // Додаємо дві книги одразу
            Books.Add(new Book { Title = "Бійцівський клуб", Author = "Чак Поланік", Year = 1991 });
            Books.Add(new Book { Title = "Пригоди Шерлока Холмса", Author = "Артур Конан Дойл", Year = 1892 });

            AddBookCommand = new RelayCommand(AddBook);
            DeleteBookCommand = new RelayCommand(DeleteBook, () => SelectedBook != null);
        }

        private void AddBook()
        {
            var book = new Book
            {
                Title = "Нова книга",
                Author = "Автор",
                Year = 2024
            };

            Books.Add(book);
            SelectedBook = book;
        }

        private void DeleteBook()
        {
            if (SelectedBook != null)
                Books.Remove(SelectedBook);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
