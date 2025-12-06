using System;
using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; set; } = DateTime.Now;
        public string Diagnosis { get; set; } = "";
        public string Symptoms { get; set; } = "";
        public string Treatment { get; set; } = "";
        public string Prescription { get; set; } = "";
        public string Notes { get; set; } = "";
        public Doctor AttendingDoctor { get; set; } = null!;
        public List<string> LabResults { get; set; } = new List<string>();
        public List<string> ImagingResults { get; set; } = new List<string>();
        
        public string GetRecordSummary()
        {
            return $"{RecordDate:yyyy-MM-dd}: {Diagnosis} - {Treatment}";
        }
        
        public void AddLabResult(string result)
        {
            LabResults.Add(result);
        }
        
        public void AddImagingResult(string result)
        {
            ImagingResults.Add(result);
        }
    }
}