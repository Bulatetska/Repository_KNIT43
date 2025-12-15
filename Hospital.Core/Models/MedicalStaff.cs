using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class MedicalStaff
    {
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Nurse> Nurses { get; set; } = new List<Nurse>();

        public int GetTotalStaffCount() => Doctors.Count + Nurses.Count;
    }
}