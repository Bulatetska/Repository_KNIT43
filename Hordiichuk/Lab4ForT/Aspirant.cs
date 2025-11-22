// Lab4ForT/Aspirant.cs
namespace Lab4ForT
{
    public class Aspirant : Student
    {
        public string DissertationTopic { get; private set; }

        public Aspirant(string surname, int course, string recordBook, string topic)
            : base(surname, course, recordBook)
        {
            if (string.IsNullOrWhiteSpace(topic))
                throw new ArgumentException("DissertationTopic не може бути порожньою.", nameof(topic));

            DissertationTopic = topic;
        }
    }
}
