using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Core.Models
{
    public class MedicalHospital
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Nurse> Nurses { get; set; } = new List<Nurse>();

        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
            Console.WriteLine($"Patient {patient.GetFullName()} registered");
        }

        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
            Console.WriteLine($"Dr. {doctor.GetFullName()} joined hospital");
        }

        public List<Appointment> GetTodaysAppointments()
        {
            return Doctors.SelectMany(d => d.Appointments)
                         .Where(a => a.AppointmentDate.Date == DateTime.Today)
                         .ToList();
        }

        public int GetTotalStaffCount() => Doctors.Count + Nurses.Count;

        public Department? FindDepartment(string name)
        {
            return Departments.FirstOrDefault(d =>
                d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}