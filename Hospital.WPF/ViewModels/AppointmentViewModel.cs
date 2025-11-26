using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Hospital.Core.Models;
using Hospital.Core.Services;

namespace Hospital.WPF.ViewModels
{
    public class AppointmentViewModel : BaseViewModel
    {
        private HospitalService _hospitalService;
        
        public ObservableCollection<Patient> Patients { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Appointment> Appointments { get; set; }

        public Patient? SelectedPatient { get; set; }
        public Doctor? SelectedDoctor { get; set; }
        public string Reason { get; set; } = "";

        public ICommand ScheduleAppointmentCommand { get; }

        public AppointmentViewModel(HospitalService hospitalService, 
                                  ObservableCollection<Patient> patients,
                                  ObservableCollection<Doctor> doctors,
                                  ObservableCollection<Appointment> appointments)
        {
            _hospitalService = hospitalService;
            Patients = patients;
            Doctors = doctors;
            Appointments = appointments;

            ScheduleAppointmentCommand = new RelayCommand(ScheduleAppointment, CanScheduleAppointment);
        }

        private bool CanScheduleAppointment()
        {
            return SelectedPatient != null && 
                   SelectedDoctor != null && 
                   !string.IsNullOrWhiteSpace(Reason);
        }

        private void ScheduleAppointment()
        {
            if (SelectedPatient == null || SelectedDoctor == null) return;

            var appointment = _hospitalService.ScheduleAppointment(
                SelectedPatient, 
                SelectedDoctor, 
                DateTime.Now.AddDays(1), 
                Reason
            );

            Appointments.Add(appointment);
            
            // Clear form
            SelectedPatient = null;
            SelectedDoctor = null;
            Reason = "";
            OnPropertyChanged(nameof(SelectedPatient));
            OnPropertyChanged(nameof(SelectedDoctor));
            OnPropertyChanged(nameof(Reason));
        }
    }
}