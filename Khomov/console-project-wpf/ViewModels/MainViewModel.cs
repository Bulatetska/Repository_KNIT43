using System.Collections.ObjectModel;
using ConsoleProject.Services;
using ConsoleProject.Models;
using ConsoleProject.Interfaces;

namespace ConsoleProjectWpf.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly Library _library = new();

    public ObservableCollection<LibraryItem> Items { get; } = new();

    private LibraryItem? _selectedItem;
    public LibraryItem? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (SetProperty(ref _selectedItem, value))
            {
                BorrowCommand.RaiseCanExecuteChanged();
                ReturnCommand.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(CanBorrow));
                OnPropertyChanged(nameof(CanReturn));
            }
        }
    }

    private string _searchQuery = string.Empty;
    public string SearchQuery
    {
        get => _searchQuery;
        set => SetProperty(ref _searchQuery, value);
    }

    public RelayCommand SearchCommand { get; }
    public RelayCommand BorrowCommand { get; }
    public RelayCommand ReturnCommand { get; }

    public bool CanBorrow => SelectedItem is IBorrowable b && !b.IsBorrowed;
    public bool CanReturn => SelectedItem is IBorrowable b && b.IsBorrowed;

    public MainViewModel()
    {
        // sample data
        var librarian = new Librarian("Anna");
        var member = new Member("CurrentUser");
        _library.RegisterMember(member);
        librarian.AddItem(_library, new Book("Clean Code", "Robert C. Martin", 2008));
        librarian.AddItem(_library, new Magazine("National Geographic", 202, 2024));
        librarian.AddItem(_library, new Dvd("Interstellar", 169, 2014));

        foreach (var item in _library.Items) Items.Add(item);

        SearchCommand = new RelayCommand(Search);
        BorrowCommand = new RelayCommand(Borrow, () => CanBorrow);
        ReturnCommand = new RelayCommand(Return, () => CanReturn);
    }

    private void Search()
    {
        Items.Clear();
        foreach (var item in _library.Search(SearchQuery)) Items.Add(item);
    }

    private void Borrow()
    {
        if (SelectedItem is null) return;
        var member = _library.Members.First(); // simplistic
        _library.BorrowItem(SelectedItem.Id, member.Id);
        BorrowCommand.RaiseCanExecuteChanged();
        ReturnCommand.RaiseCanExecuteChanged();
        OnPropertyChanged(nameof(CanBorrow));
        OnPropertyChanged(nameof(CanReturn));
    }

    private void Return()
    {
        if (SelectedItem is null) return;
        _library.ReturnItem(SelectedItem.Id);
        BorrowCommand.RaiseCanExecuteChanged();
        ReturnCommand.RaiseCanExecuteChanged();
        OnPropertyChanged(nameof(CanBorrow));
        OnPropertyChanged(nameof(CanReturn));
    }
}

