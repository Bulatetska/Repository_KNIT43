using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

public class BookViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Book> Books { get; set; } = new();

    private string? newTitle;
    public string? NewTitle
    {
        get => newTitle;
        set { newTitle = value; OnPropertyChanged(nameof(NewTitle)); }
    }

    private string? newAuthor;
    public string? NewAuthor
    {
        get => newAuthor;
        set { newAuthor = value; OnPropertyChanged(nameof(NewAuthor)); }
    }

    private string? newYear;
    public string? NewYear
    {
        get => newYear;
        set { newYear = value; OnPropertyChanged(nameof(NewYear)); }
    }

    private Book? selectedBook;
    public Book? SelectedBook
    {
        get => selectedBook;
        set { selectedBook = value; OnPropertyChanged(nameof(SelectedBook)); }
    }

    public ICommand AddBookCommand { get; }
    public ICommand DeleteBookCommand { get; }

    public BookViewModel()
    {
        AddBookCommand = new RelayCommand(_ => AddBook());
        DeleteBookCommand = new RelayCommand(_ => DeleteBook(), _ => SelectedBook != null);
    }

    private void AddBook()
    {
        if (!int.TryParse(NewYear, out int year)) return;

        Books.Add(new Book
        {
            Title = NewTitle ?? "",
            Author = NewAuthor ?? "",
            Year = year
        });

        NewTitle = "";
        NewAuthor = "";
        NewYear = "";
    }

    private void DeleteBook()
    {
        if (SelectedBook != null)
            Books.Remove(SelectedBook);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
