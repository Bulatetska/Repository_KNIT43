using System;
using System.Collections.Generic;
using Hospital.Core.Models;

namespace Hospital.Core.Interfaces
{
    public interface IAppointmentService
    {
        Appointment ScheduleAppointment(Patient patient, Doctor doctor, DateTime date, string reason);
        void CancelAppointment(int appointmentId);
        List<Appointment> GetUpcomingAppointments(Patient patient);

        void CompleteAppointment(int appointmentId, string diagnosis, string treatment);
        Appointment? GetAppointmentById(int id);
    }
}