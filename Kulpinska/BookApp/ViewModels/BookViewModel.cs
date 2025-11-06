using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BookApp.Models;

namespace BookApp.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private Book _selectedBook;

        public ObservableCollection<Book> Books { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        public BookViewModel()
        {
            Books = new ObservableCollection<Book>
            {
                new Book { Title = "Місто", Author = "Валер’ян Підмогильний", Year = 1928 },
                new Book { Title = "Тигролови", Author = "Іван Багряний", Year = 1944 }
            };

            AddCommand = new RelayCommand(_ => AddBook());
            DeleteCommand = new RelayCommand(_ => DeleteBook(), _ => SelectedBook != null);
        }

        private void AddBook()
        {
            var newBook = new Book { Title = "Нова книга", Author = "Автор", Year = 2025 };
            Books.Add(newBook);
            SelectedBook = newBook;
        }

        private void DeleteBook()
        {
            if (SelectedBook != null)
                Books.Remove(SelectedBook);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
