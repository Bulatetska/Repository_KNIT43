using System;

namespace Hospital.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Patient Patient { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
        public string Reason { get; set; } = "";
        public string Notes { get; set; } = "";
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
        public decimal Cost { get; set; }
        
        public string GetAppointmentInfo()
        {
            return $"#{Id}: {Patient.GetFullName()} with Dr. {Doctor.LastName} - {AppointmentDate:MMM dd, yyyy HH:mm}";
        }
        
        public bool IsUpcoming() => AppointmentDate > DateTime.Now && Status == AppointmentStatus.Scheduled;
        
        public void Reschedule(DateTime newDate)
        {
            AppointmentDate = newDate;
            Status = AppointmentStatus.Rescheduled;
        }
    }
}