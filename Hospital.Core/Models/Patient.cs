using System;
using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Patient : Person
    {
        public string MedicalCardNumber { get; set; } = "";
        public string BloodType { get; set; } = "";
        public List<string> Allergies { get; set; } = new List<string>();
        public List<MedicalRecord> MedicalHistory { get; set; } = new List<MedicalRecord>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        
        // Додайте цю властивість для біндингу в WPF
        public string FullName => GetFullName();
        
        public string GetMedicalSummary()
        {
            return $"{GetFullName()} | Card: {MedicalCardNumber} | Blood: {BloodType}";
        }
        
        public void AddAllergy(string allergy)
        {
            Allergies.Add(allergy);
        }
    }
}
