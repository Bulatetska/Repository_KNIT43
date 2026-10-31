namespace ClassesLab;
public class Student
{
    public string Surname { get; set; }
    public int Course { get; set; }
    public string RecordBook { get; set; }
    public Student(string surname, int course, string recordBook)
    { Surname = surname; Course = course; RecordBook = recordBook; }
    public virtual void Print() => Console.WriteLine($"Прізвище: {Surname}; Курс: {Course}; Залікова книжка: {RecordBook}");
}
