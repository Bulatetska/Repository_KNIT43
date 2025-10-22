using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClasses
{
    public class Student
    {
        private string surname;
        private int course;
        private string recordBookNumber;

        public string Surname { get => surname; set => surname = value; }
        public int Course { get => course; set => course = value; }
        public string RecordBookNumber { get => recordBookNumber; set => recordBookNumber = value; }

        public Student(string surname, int course, string recordBookNumber)
        {
            this.surname = surname;
            this.course = course;
            this.recordBookNumber = recordBookNumber;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Surname: {surname}, Course: {course}, Record Book: {recordBookNumber}");
        }
    }

    public class Aspirant : Student
    {
        public Aspirant(string surname, int course, string recordBookNumber)
            : base(surname, course, recordBookNumber) { }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("This is an Aspirant.");
        }
    }
}
