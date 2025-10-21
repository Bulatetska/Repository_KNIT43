using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BookManagementApp.Models;

namespace BookManagementApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Book? _selectedBook;
        private string? _newTitle;
        private string? _newAuthor;
        private int _newYear = DateTime.Now.Year;

        public ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>();

        public Book? SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
                
                if (value != null)
                {
                    NewTitle = value.Title;
                    NewAuthor = value.Author;
                    NewYear = value.Year;
                }
                else
                {
                    NewTitle = string.Empty;
                    NewAuthor = string.Empty;
                    NewYear = DateTime.Now.Year;
                }
            }
        }

        public string? NewTitle
        {
            get => _newTitle;
            set
            {
                _newTitle = value;
                OnPropertyChanged(nameof(NewTitle));
                OnPropertyChanged(nameof(CanAddBook));
            }
        }

        public string? NewAuthor
        {
            get => _newAuthor;
            set
            {
                _newAuthor = value;
                OnPropertyChanged(nameof(NewAuthor));
                OnPropertyChanged(nameof(CanAddBook));
            }
        }

        public int NewYear
        {
            get => _newYear;
            set
            {
                _newYear = value;
                OnPropertyChanged(nameof(NewYear));
                OnPropertyChanged(nameof(CanAddBook));
            }
        }

        public bool CanAddBook => !string.IsNullOrWhiteSpace(NewTitle) && 
                                 !string.IsNullOrWhiteSpace(NewAuthor) && 
                                 NewYear >= 1000 && NewYear <= DateTime.Now.Year + 5;

        public bool CanDeleteBook => SelectedBook != null;

        // Команди
        public ICommand AddBookCommand { get; }
        public ICommand DeleteBookCommand { get; }
        public ICommand UpdateBookCommand { get; }

        public MainViewModel()
        {
            AddBookCommand = new RelayCommand(AddBook, _ => CanAddBook);
            DeleteBookCommand = new RelayCommand(DeleteBook, _ => CanDeleteBook);
            UpdateBookCommand = new RelayCommand(UpdateBook, _ => CanDeleteBook && CanAddBook);

            // Додаємо тестові дані
            LoadSampleData();
        }

        private void AddBook(object? parameter)
        {
            if (NewTitle != null && NewAuthor != null)
            {
                var book = new Book
                {
                    Title = NewTitle,
                    Author = NewAuthor,
                    Year = NewYear
                };

                Books.Add(book);
                
                // Очищаємо поля після додавання
                ClearForm();
            }
        }

        private void DeleteBook(object? parameter)
        {
            if (SelectedBook != null)
            {
                Books.Remove(SelectedBook);
                SelectedBook = null;
                ClearForm();
            }
        }

        private void UpdateBook(object? parameter)
        {
            if (SelectedBook != null && NewTitle != null && NewAuthor != null)
            {
                SelectedBook.Title = NewTitle;
                SelectedBook.Author = NewAuthor;
                SelectedBook.Year = NewYear;
            }
        }

        private void ClearForm()
        {
            NewTitle = string.Empty;
            NewAuthor = string.Empty;
            NewYear = DateTime.Now.Year;
        }

        private void LoadSampleData()
        {
            Books.Add(new Book { Title = "Гаррі Поттер і філософський камінь", Author = "Дж. К. Роулінг", Year = 1997 });
            Books.Add(new Book { Title = "Володар перснів", Author = "Дж. Р. Р. Толкін", Year = 1954 });
            Books.Add(new Book { Title = "1984", Author = "Джордж Орвелл", Year = 1949 });
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}