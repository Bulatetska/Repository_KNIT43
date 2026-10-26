using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LibraryMVVM.Models;

public class Book : INotifyPropertyChanged
{
    private string _title = "";
    private string _author = "";
    private int _year;

    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }

    public string Author
    {
        get => _author;
        set
        {
            if (_author != value)
            {
                _author = value;
                OnPropertyChanged();
            }
        }
    }

    public int Year
    {
        get => _year;
        set
        {
            if (_year != value)
            {
                _year = value;
                OnPropertyChanged();
            }
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

    public override string ToString()
    {
        return $"{Title} — {Author} ({Year})";
    }
}