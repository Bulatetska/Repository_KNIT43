using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace LabTenWpf;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private string _userName = string.Empty;
    private string _greeting = string.Empty;

    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName == value)
                return;

            _userName = value;
            OnPropertyChanged();
        }
    }

    public string Greeting
    {
        get => _greeting;
        set
        {
            if (_greeting == value)
                return;

            _greeting = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void ConfirmButton_Click(object sender, RoutedEventArgs e)
    {
        string name = UserName.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            Greeting = "Введіть своє ім'я.";
            return;
        }

        Greeting = $"Привіт, {name}!";
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
