using System.Collections.ObjectModel;
using System.Windows.Input;
using Hospital.Core.Models;
using Hospital.Core.Services;

namespace Hospital.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private MedicalHospital _hospital;
        private HospitalService _hospitalService = null!;
        private PatientService _patientService = null!;

        private object _currentView = null!;
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ObservableCollection<Patient> Patients { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Appointment> Appointments { get; set; }

        // Commands
        public ICommand ShowPatientsCommand { get; }
        public ICommand ShowDoctorsCommand { get; }
        public ICommand ShowAppointmentsCommand { get; }
        public ICommand ShowHospitalOverviewCommand { get; }

        public MainViewModel()
        {
            // Ініціалізуємо колекції ПЕРШИМИ
            Patients = new ObservableCollection<Patient>();
            Doctors = new ObservableCollection<Doctor>();
            Appointments = new ObservableCollection<Appointment>();

            InitializeHospital();
            
            // Initialize commands
            ShowPatientsCommand = new RelayCommand(ShowPatients);
            ShowDoctorsCommand = new RelayCommand(ShowDoctors);
            ShowAppointmentsCommand = new RelayCommand(ShowAppointments);
            ShowHospitalOverviewCommand = new RelayCommand(ShowHospitalOverview);

            // Default view
            CurrentView = new HospitalOverviewViewModel(_hospital);
        }

        private void InitializeHospital()
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

            // Add sample data
            AddSampleData();
        }

        private void AddSampleData()
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

            var patient1 = _patientService.RegisterPatient("Alice", "Brown", "+1-555-0001", "alice@email.com");
            var patient2 = _patientService.RegisterPatient("Bob", "Wilson", "+1-555-0002", "bob@email.com");

            // Оновлюємо колекції з перевіркою на null
            RefreshCollections();
        }

        private void RefreshCollections()
        {
            // Очищаємо та додаємо пацієнтів
            Patients.Clear();
            if (_hospital.Patients != null)
            {
                foreach (var patient in _hospital.Patients)
                    Patients.Add(patient);
            }

            // Очищаємо та додаємо лікарів
            Doctors.Clear();
            if (_hospital.Doctors != null)
            {
                foreach (var doctor in _hospital.Doctors)
                    Doctors.Add(doctor);
            }
        }

        private void ShowPatients() 
        { 
            CurrentView = new PatientViewModel(_hospital, _patientService, Patients); 
        }
        
        private void ShowDoctors() 
        { 
            CurrentView = new DoctorViewModel(Doctors); 
        }
        
        private void ShowAppointments() 
        { 
            CurrentView = new AppointmentViewModel(_hospitalService, Patients, Doctors, Appointments); 
        }
        
        private void ShowHospitalOverview() 
        { 
            CurrentView = new HospitalOverviewViewModel(_hospital); 
        }
    }
}