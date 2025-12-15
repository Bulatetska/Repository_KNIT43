using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string HeadDoctor { get; set; } = "";
        public int RoomNumber { get; set; }
        public string PhoneExtension { get; set; } = "";
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Nurse> Nurses { get; set; } = new List<Nurse>();

        public int GetStaffCount() => Doctors.Count + Nurses.Count;

        public string GetContactInfo()
        {
            return $"{Name} | Room: {RoomNumber} | Ext: {PhoneExtension}";
        }
    }
}