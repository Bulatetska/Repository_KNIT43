// Lab4ForT/Student.cs
namespace Lab4ForT
{
    public class Student
    {
        public string Surname { get; private set; }
        public int Course { get; private set; }
        public string RecordBook { get; private set; }

        public Student(string surname, int course, string recordBook)
        {
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentException("Surname не може бути порожнім.", nameof(surname));
            if (course <= 0)
                throw new ArgumentOutOfRangeException(nameof(course), "Course повинен бути додатним.");
            if (string.IsNullOrWhiteSpace(recordBook))
                throw new ArgumentException("RecordBook не може бути порожнім.", nameof(recordBook));

            Surname = surname;
            Course = course;
            RecordBook = recordBook;
        }
    }
}
