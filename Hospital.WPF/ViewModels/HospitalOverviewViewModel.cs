using Hospital.Core.Models;

namespace Hospital.WPF.ViewModels
{
    public class HospitalOverviewViewModel : BaseViewModel
    {
        private MedicalHospital _hospital;

        public string HospitalName => _hospital?.Name ?? "Hospital Name Not Available";
        public string Address => _hospital?.Address ?? "Address Not Available";
        public string Phone => _hospital?.Phone ?? "Phone Not Available";
        public int TotalStaff => _hospital?.GetTotalStaffCount() ?? 0;
        public int TotalPatients => _hospital?.Patients?.Count ?? 0;
        public int TotalDepartments => _hospital?.Departments?.Count ?? 0;
        public int TodaysAppointments => _hospital?.GetTodaysAppointments()?.Count ?? 0;

        public HospitalOverviewViewModel(MedicalHospital hospital)
        {
            _hospital = hospital ?? new MedicalHospital { Name = "Default Hospital" };
        }
    }
}