using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentManagementSystem;

public partial class MainWindow : Window
{
    private readonly StudentManager manager = new();

    private readonly string filePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "StudentManagementSystem",
        "students.txt"
    );

    public MainWindow()
    {
        InitializeComponent();

        manager.LoadFromFile(filePath);

        RefreshStudents();
        manager.PrintReport();
    }

    private void RefreshStudents()
    {
        StudentsGrid.ItemsSource = null;
        StudentsGrid.ItemsSource = manager.GetSortedStudents();

        TotalStudentsText.Text = manager.Students.Count.ToString();
        AverageMarkText.Text = manager.GetGroupAverage().ToString("F2");
        ExcellentStudentsText.Text = manager.GetExcellentStudents().Count.ToString();
    }

    private void AddStudent_Click(object sender, RoutedEventArgs e)
    {
        string name = NameInput.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Please enter a student name.");
            return;
        }

        if (!int.TryParse(AgeInput.Text, out int age) || age <= 0)
        {
            MessageBox.Show("Please enter a valid age.");
            return;
        }

        if (!double.TryParse(
            MarkInput.Text.Replace(',', '.'),
            System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture,
            out double mark) || mark < 0 || mark > 100)
        {
            MessageBox.Show("Average mark must be between 0 and 100.");
            return;
        }

        Student student = new Student
        {
            Name = name,
            Age = age,
            AverageMark = mark
        };

        manager.AddStudent(student);

        manager.SaveToFile(filePath);

        RefreshStudents();

        Console.WriteLine("\nSTUDENT ADDED:");
        Console.WriteLine($"Name: {student.Name}");
        Console.WriteLine($"Age: {student.Age}");
        Console.WriteLine($"Average mark: {student.AverageMark:F2}");
        Console.WriteLine($"Status: {student.Status}");

        manager.PrintReport();

        NameInput.Clear();
        AgeInput.Clear();
        MarkInput.Clear();
    }

    private void SaveToFile_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            manager.SaveToFile(filePath);

            MessageBox.Show(
                "Students have been successfully saved.",
                "Save successful",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            manager.PrintReport();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving file: {ex.Message}");
        }
    }

    private void LoadFromFile_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            manager.LoadFromFile(filePath);

            RefreshStudents();
            manager.PrintReport();

            MessageBox.Show(
                "Students have been successfully loaded.",
                "Load successful",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading file: {ex.Message}");
        }
    }

    private void ShowExcellent_Click(object sender, RoutedEventArgs e)
    {
        StudentsGrid.ItemsSource = null;
        StudentsGrid.ItemsSource = manager.GetExcellentStudents();
    }

    private void ShowAll_Click(object sender, RoutedEventArgs e)
    {
        RefreshStudents();
    }
}