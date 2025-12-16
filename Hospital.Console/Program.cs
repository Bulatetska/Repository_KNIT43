using System;
using Hospital.Core.Models;
using Hospital.Core.Services;

namespace Hospital.ConsoleApp  
{
    class Program
    {
        private static MedicalHospital _hospital;
        private static HospitalService _hospitalService;
        private static PatientService _patientService;

        static void Main(string[] args)
        {
            InitializeHospital();
            ShowMainMenu();
        }

        private static void InitializeHospital()
        {
            _hospital = new MedicalHospital
            { 
                Name = "City General Hospital",
                Address = "123 Medical Center Drive",
                Phone = "+1-555-0123",
                Email = "info@citygeneral.org"
            };

            _hospitalService = new HospitalService(_hospital);
            _patientService = new PatientService(_hospital);

            AddSampleData();
        }

        private static void AddSampleData()
        {
            var doctor1 = new Doctor 
            { 
                Id = 1, 
                FirstName = "John", 
                LastName = "Smith", 
                Specialization = "Cardiology",
                LicenseNumber = "MD12345",
                YearsOfExperience = 15
            };

            var doctor2 = new Doctor 
            { 
                Id = 2, 
                FirstName = "Sarah", 
                LastName = "Johnson", 
                Specialization = "Pediatrics",
                LicenseNumber = "MD67890",
                YearsOfExperience = 8
            };

            _hospital.AddDoctor(doctor1);
            _hospital.AddDoctor(doctor2);

            var cardiology = new Department 
            { 
                Id = 1, 
                Name = "Cardiology", 
                HeadDoctor = "Dr. John Smith",
                RoomNumber = 101
            };

            _hospital.Departments.Add(cardiology);

            // Додамо тестового пацієнта
            var patient = _patientService.RegisterPatient("Alice", "Brown", "+1-555-0001", "alice@email.com");
            Console.WriteLine("✅ Sample data added successfully!");
        }

        private static void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("🏥 Hospital Management System");
                Console.WriteLine("═════════════════════════════");
                Console.WriteLine("1. Patient Management");
                Console.WriteLine("2. Doctor Management");
                Console.WriteLine("3. Appointment Scheduling");
                Console.WriteLine("4. Medical Records");
                Console.WriteLine("5. Hospital Overview");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ShowPatientMenu(); break;
                    case "2": ShowDoctorMenu(); break;
                    case "3": ShowAppointmentMenu(); break;
                    case "4": ShowMedicalRecordsMenu(); break;
                    case "5": ShowHospitalOverview(); break;
                    case "6": return;
                    default: 
                        Console.WriteLine("Invalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Решта методів залишається як у попередньому варіанті, але звичайний Console
        private static void ShowPatientMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("👥 Patient Management");
                Console.WriteLine("══════════════════════");
                Console.WriteLine("1. Register New Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RegisterNewPatient();
                        break;
                    case "2":
                        DisplayAllPatients();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void RegisterNewPatient()
        {
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Phone: ");
            var phone = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("❌ First name and last name are required!");
                Console.ReadKey();
                return;
            }

            var patient = _patientService.RegisterPatient(firstName, lastName, phone ?? "", email ?? "");
            Console.WriteLine($"✅ Patient registered successfully!");
            Console.WriteLine($"Medical Card: {patient.MedicalCardNumber}");
            Console.ReadKey();
        }

        private static void DisplayAllPatients()
        {
            Console.WriteLine("\nRegistered Patients:");
            if (_hospital.Patients.Count == 0)
            {
                Console.WriteLine("No patients registered yet.");
            }
            else
            {
                foreach (var patient in _hospital.Patients)
                {
                    Console.WriteLine($"- {patient.GetFullName()} | Card: {patient.MedicalCardNumber} | Phone: {patient.Phone}");
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void ShowDoctorMenu()
        {
            Console.Clear();
            Console.WriteLine("👨‍⚕️ Doctor Management");
            Console.WriteLine("════════════════════");
            Console.WriteLine("Registered Doctors:");
            foreach (var doctor in _hospital.Doctors)
            {
                Console.WriteLine($"- Dr. {doctor.GetFullName()} | {doctor.Specialization} | Experience: {doctor.YearsOfExperience} years");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void ShowHospitalOverview()
        {
            Console.Clear();
            Console.WriteLine("🏥 Hospital Overview");
            Console.WriteLine("═════════════════════");
            Console.WriteLine($"Hospital: {_hospital.Name}");
            Console.WriteLine($"Address: {_hospital.Address}");
            Console.WriteLine($"Total Staff: {_hospital.GetTotalStaffCount()}");
            Console.WriteLine($"Total Patients: {_hospital.Patients.Count}");
            Console.WriteLine($"Departments: {_hospital.Departments.Count}");
            Console.WriteLine($"Today's Appointments: {_hospital.GetTodaysAppointments().Count}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void ShowAppointmentMenu()
        {
            Console.Clear();
            Console.WriteLine("📅 Appointment Scheduling");
            Console.WriteLine("═════════════════════════");
            Console.WriteLine("Feature coming soon...");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void ShowMedicalRecordsMenu()
        {
            Console.Clear();
            Console.WriteLine("📋 Medical Records");
            Console.WriteLine("═══════════════════");
            Console.WriteLine("Feature coming soon...");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}