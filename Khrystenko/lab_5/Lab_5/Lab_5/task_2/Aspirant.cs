using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5.task_2
{
    internal class Aspirant : Student
    {
        private string dissertationTopic;

        public Aspirant(string lastName, int course, int recordBookNumber, string dissertationTopic)
            : base(lastName, course, recordBookNumber)
        {
            this.dissertationTopic = dissertationTopic;
        }

        public string DissertationTopic
        {
            get { return dissertationTopic; }
            set { dissertationTopic = value; }
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Topic: " + dissertationTopic);
        }
    }
}
