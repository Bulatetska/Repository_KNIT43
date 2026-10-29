using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace TechStore.Wpf;

public partial class App : Application
{
    private static readonly string LogFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "TechStoreWpf", "startup.log");

    public static void WriteLog(string message)
    {
        try
        {
            string? directory = Path.GetDirectoryName(LogFilePath);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);
            File.AppendAllText(LogFilePath,
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}",
                Encoding.UTF8);
        }
        catch
        {
            // Помилка запису журналу не повинна заважати запуску програми.
        }
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        DispatcherUnhandledException += OnDispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException += (_, args) =>
            WriteLog("Необроблена помилка: " + args.ExceptionObject);

        WriteLog("Запуск TechStore.Wpf. Створюємо MainWindow.");
        try
        {
            var window = new MainWindow();
            MainWindow = window;
            WriteLog("MainWindow створено. Відкриваємо вікно.");
            window.Show();
            WriteLog("Window.Show() виконано.");
        }
        catch (Exception ex)
        {
            ShowError("Помилка запуску TechStore WPF", ex);
            Shutdown(1);
        }
    }

    private void OnDispatcherUnhandledException(object sender,
        DispatcherUnhandledExceptionEventArgs e)
    {
        ShowError("Помилка у TechStore WPF", e.Exception);
        e.Handled = true;
    }

    private static void ShowError(string title, Exception ex)
    {
        WriteLog(title + ": " + ex);
        MessageBox.Show(
            ex.ToString() + "\n\nЖурнал: " + LogFilePath,
            title,
            MessageBoxButton.OK,
            MessageBoxImage.Error);
    }
}
