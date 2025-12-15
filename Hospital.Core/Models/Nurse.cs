using System;
using System.Collections.Generic;
using Hospital.Core.Interfaces;

namespace Hospital.Core.Models
{
    public class Nurse : Person, IMedicalStaff
    {
        public string Department { get; set; } = "";
        public string Shift { get; set; } = "";
        public List<string> Responsibilities { get; set; } = new List<string>();

        public void PerformExamination(Patient patient)
        {
            Console.WriteLine($"Nurse {LastName} is checking vital signs for {patient.GetFullName()}");
        }

        public string GetSchedule()
        {
            return $"Nurse {LastName}: {Shift} shift in {Department}";
        }

        public void AddResponsibility(string responsibility)
        {
            Responsibilities.Add(responsibility);
        }
    }
}