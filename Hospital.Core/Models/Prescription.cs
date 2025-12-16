using System;

namespace Hospital.Core.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string MedicationName { get; set; } = "";
        public string Dosage { get; set; } = "";
        public string Frequency { get; set; } = "";
        public int DurationDays { get; set; }
        public string Instructions { get; set; } = "";
        public DateTime PrescribedDate { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; }
        public Doctor PrescribingDoctor { get; set; } = null!;
        public Patient Patient { get; set; } = null!;

        public bool IsActive() => ExpiryDate > DateTime.Now;

        public string GetPrescriptionInfo()
        {
            return $"{MedicationName} - {Dosage} - {Frequency} for {DurationDays} days";
        }
    }
}