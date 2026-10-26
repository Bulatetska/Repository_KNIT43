using System.Windows;
using LibraryMVVM.ViewModels;

namespace LibraryMVVM;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new BookViewModel();
    }
}