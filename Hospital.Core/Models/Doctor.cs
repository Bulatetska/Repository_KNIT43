using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Core.Interfaces;

namespace Hospital.Core.Models
{
    public class Doctor : Person, IMedicalStaff
    {
        public string Specialization { get; set; } = "";
        public string LicenseNumber { get; set; } = "";
        public int YearsOfExperience { get; set; }
        public List<string> Certifications { get; set; } = new List<string>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<Patient> CurrentPatients { get; set; } = new List<Patient>();

        // Додайте цю властивість для біндингу в WPF
        public string FullName => GetFullName();

        public void PerformExamination(Patient patient)
        {
            Console.WriteLine($"Dr. {LastName} is examining {patient.GetFullName()}");
        }

        public string GetSchedule()
        {
            var upcoming = Appointments?.Where(a => a.AppointmentDate > DateTime.Now).Count() ?? 0;
            return $"Dr. {LastName}: {upcoming} upcoming appointments";
        }

        public string GetSpecializationInfo()
        {
            return $"{Specialization} | Experience: {YearsOfExperience} years";
        }
    }
}