namespace ClassesLab;
public class Aspirant : Student
{
    public string DissertationTopic { get; set; }
    public Aspirant(string surname, int course, string recordBook, string dissertationTopic)
        : base(surname, course, recordBook) => DissertationTopic = dissertationTopic;
    public override void Print()
    { base.Print(); Console.WriteLine($"Тема дисертації: {DissertationTopic}"); }
}
