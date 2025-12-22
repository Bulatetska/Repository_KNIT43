using System.Windows;
using ConsoleProjectWpf.ViewModels;

namespace ConsoleProjectWpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}

