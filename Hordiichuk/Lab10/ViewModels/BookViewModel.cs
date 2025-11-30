using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Lab10.Models;

namespace Lab10.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Book> Books { get; set; }

        private Book? selectedBook;
        public Book? SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;

                // Коли ми вибираємо книгу зі списку — поля заповнюються її даними
                if (selectedBook != null)
                {
                    TitleField = selectedBook.Title;
                    AuthorField = selectedBook.Author;
                    YearField = selectedBook.Year.ToString();
                }

                OnPropertyChanged();
            }
        }

        // Одні й ті ж поля слугують для додавання І редагування
        private string titleField = "";
        private string authorField = "";
        private string yearField = "";

        public string TitleField
        {
            get => titleField;
            set
            {
                titleField = value;
                OnPropertyChanged();

                // Якщо вибрана книга → редагуємо її
                if (SelectedBook != null)
                    SelectedBook.Title = value;
            }
        }

        public string AuthorField
        {
            get => authorField;
            set
            {
                authorField = value;
                OnPropertyChanged();

                if (SelectedBook != null)
                    SelectedBook.Author = value;
            }
        }

        public string YearField
        {
            get => yearField;
            set
            {
                yearField = value;
                OnPropertyChanged();

                if (SelectedBook != null && int.TryParse(value, out var y))
                    SelectedBook.Year = y;
            }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public BookViewModel()
        {
            Books = new ObservableCollection<Book>();

            AddCommand = new RelayCommand(_ => AddBook());
            DeleteCommand = new RelayCommand(_ => DeleteBook(), _ => SelectedBook != null);
        }

        private void AddBook()
        {
            string title = string.IsNullOrWhiteSpace(TitleField) ? "Без назви" : TitleField;
            string author = string.IsNullOrWhiteSpace(AuthorField) ? "Невідомий" : AuthorField;
            int year = int.TryParse(YearField, out var y) ? y : 0;

            Books.Add(new Book
            {
                Title = title,
                Author = author,
                Year = year
            });

            // очищаємо форму
            TitleField = "";
            AuthorField = "";
            YearField = "";

            // відключаємо режим редагування
            SelectedBook = null;
        }

        private void DeleteBook()
        {
            if (SelectedBook != null)
            {
                Books.Remove(SelectedBook);
                SelectedBook = null;

                TitleField = "";
                AuthorField = "";
                YearField = "";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

}
