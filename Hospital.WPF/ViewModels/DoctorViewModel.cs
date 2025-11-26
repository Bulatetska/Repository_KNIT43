using System.Collections.ObjectModel;
using Hospital.Core.Models;

namespace Hospital.WPF.ViewModels
{
    public class DoctorViewModel : BaseViewModel
    {
        public ObservableCollection<Doctor> Doctors { get; set; }

        public DoctorViewModel(ObservableCollection<Doctor> doctors)
        {
            Doctors = doctors;
        }
    }
}