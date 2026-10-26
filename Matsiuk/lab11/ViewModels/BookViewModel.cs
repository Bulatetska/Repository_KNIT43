using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LibraryMVVM.Models;

namespace LibraryMVVM.ViewModels;

public class BookViewModel : INotifyPropertyChanged
{
    private Book? _selectedBook;

    public ObservableCollection<Book> Books { get; } = new();

    public Book? SelectedBook
    {
        get => _selectedBook;
        set
        {
            if (_selectedBook != value)
            {
                _selectedBook = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }

    public RelayCommand AddCommand { get; }
    public RelayCommand DeleteCommand { get; }

    public BookViewModel()
    {
        AddCommand = new RelayCommand(_ => AddBook());

        DeleteCommand = new RelayCommand(
            _ => DeleteBook(),
            _ => SelectedBook != null);

        Books.Add(new Book
        {
            Title = "Kobzar",
            Author = "Taras Shevchenko",
            Year = 1840
        });

        Books.Add(new Book
        {
            Title = "Zakhar Berkut",
            Author = "Ivan Franko",
            Year = 1883
        });
    }

    private void AddBook()
    {
        var book = new Book
        {
            Title = "New Book",
            Author = "Unknown Author",
            Year = 2026
        };

        Books.Add(book);
        SelectedBook = book;
    }

    private void DeleteBook()
    {
        if (SelectedBook is not null)
        {
            var book = SelectedBook;
            SelectedBook = null;
            Books.Remove(book);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}