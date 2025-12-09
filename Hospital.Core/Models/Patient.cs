namespace Hospital.Core.Models
{
    public class Patient : Person
    {
        public string MedicalHistory { get; set; } = string.Empty;
        public string BloodType { get; set; } = string.Empty;
        public int Age { get; set; }
        public EmergencyContact EmergencyContact { get; set; } = new EmergencyContact();
    }
}
