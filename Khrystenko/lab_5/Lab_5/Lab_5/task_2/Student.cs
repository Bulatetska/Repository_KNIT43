namespace Lab_5.task_2
{
    internal class Student
    {
        protected string lastName;
        protected int course;
        protected int recordBookNumber;


        public Student(string lastName, int course, int recordBookNumber)
        {
            this.lastName = lastName;
            this.course = course;
            this.recordBookNumber = recordBookNumber;
        }


        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int Course
        {
            get { return course; }
            set { course = value; }
        }

        public int RecordBookNumber
        {
            get { return recordBookNumber; }
            set { recordBookNumber = value; }
        }

        public virtual void Print()
        {
            Console.WriteLine("Student: " + lastName);
            Console.WriteLine("Course: " + course);
            Console.WriteLine("Book: " + recordBookNumber);
        }
    }
}
