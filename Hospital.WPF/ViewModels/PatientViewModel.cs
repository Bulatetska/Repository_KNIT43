using System.Collections.ObjectModel;
using System.Windows.Input;
using Hospital.Core.Models;
using Hospital.Core.Services;

namespace Hospital.WPF.ViewModels
{
    public class PatientViewModel : BaseViewModel
    {
        private MedicalHospital _hospital;
        private PatientService _patientService;
        
        private string _firstName = "";
        private string _lastName = "";
        private string _phone = "";
        private string _email = "";

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public ObservableCollection<Patient> Patients { get; set; }
        public ICommand AddPatientCommand { get; }

        public PatientViewModel(MedicalHospital hospital, PatientService patientService, ObservableCollection<Patient> patients)
        {
            _hospital = hospital;
            _patientService = patientService;
            Patients = patients;
            
            AddPatientCommand = new RelayCommand(AddPatient, CanAddPatient);
        }

        private bool CanAddPatient()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && 
                   !string.IsNullOrWhiteSpace(LastName);
        }

        private void AddPatient()
        {
            var patient = _patientService.RegisterPatient(FirstName, LastName, Phone, Email);
            Patients.Add(patient);
            
            // Clear form
            FirstName = "";
            LastName = "";
            Phone = "";
            Email = "";
        }
    }
}