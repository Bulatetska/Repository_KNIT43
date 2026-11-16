using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentManagementSystem;

public class StudentManager
{
    public List<Student> Students { get; set; } = new();

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public List<Student> GetExcellentStudents()
    {
        return Students
            .Where(s => s.AverageMark >= 80)
            .OrderByDescending(s => s.AverageMark)
            .ToList();
    }

    public List<Student> GetSortedStudents()
    {
        return Students
            .OrderByDescending(s => s.AverageMark)
            .ToList();
    }

    public double GetGroupAverage()
    {
        if (Students.Count == 0)
            return 0;

        return Students.Average(s => s.AverageMark);
    }

    public void SaveToFile(string filePath)
    {
    string? directory = Path.GetDirectoryName(filePath);

    if (!string.IsNullOrEmpty(directory))
        Directory.CreateDirectory(directory);

    using StreamWriter writer = new StreamWriter(filePath);

    foreach (Student student in Students)
        {
        string mark = student.AverageMark.ToString(
            System.Globalization.CultureInfo.InvariantCulture
        );

        writer.WriteLine($"{student.Name}|{student.Age}|{mark}");
        }
    }

    public void LoadFromFile(string filePath)
    {
        Students.Clear();

        if (!File.Exists(filePath))
            return;

        foreach (string line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split('|');

            if (parts.Length != 3)
                continue;

            if (!int.TryParse(parts[1], out int age))
                continue;

            if (!double.TryParse(
                parts[2],
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture,
                out double mark))
                continue;

            Students.Add(new Student
            {
                Name = parts[0],
                Age = age,
                AverageMark = mark
            });
        }
    }

    public void PrintReport()
    {
        Console.WriteLine("\n========== STUDENT REPORT ==========");

        if (Students.Count == 0)
        {
            Console.WriteLine("No students available.");
            Console.WriteLine("====================================\n");
            return;
        }

        Console.WriteLine("\nALL STUDENTS:");

        foreach (Student student in Students)
        {
            Console.WriteLine(
                $"Name: {student.Name} | Age: {student.Age} | " +
                $"Average mark: {student.AverageMark:F2} | Status: {student.Status}"
            );
        }

        Console.WriteLine("\nEXCELLENT STUDENTS (80+):");

        foreach (Student student in GetExcellentStudents())
        {
            Console.WriteLine(
                $"{student.Name} - {student.AverageMark:F2}"
            );
        }

        Console.WriteLine($"\nTotal students: {Students.Count}");
        Console.WriteLine($"Group average: {GetGroupAverage():F2}");

        Console.WriteLine("====================================\n");
    }
}