using System.Windows;
using TechStore.Wpf.ViewModels;

namespace TechStore.Wpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        App.WriteLog("MainWindow: початок InitializeComponent().");
        InitializeComponent();
        App.WriteLog("MainWindow: XAML завантажено. Створення ShopViewModel.");
        DataContext = new ShopViewModel();
        App.WriteLog("MainWindow: ShopViewModel створено.");
    }
}
