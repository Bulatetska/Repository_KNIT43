namespace StudentManagementSystem;

public class Student
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public double AverageMark { get; set; }

    public string Status => Age < 18 ? "Minor" : "Adult";
}