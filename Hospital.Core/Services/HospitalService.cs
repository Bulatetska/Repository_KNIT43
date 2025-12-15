using System;
using System.Linq;
using Hospital.Core.Models;

namespace Hospital.Core.Services
{
    public class HospitalService
    {
        private MedicalHospital _hospital;

        public HospitalService(MedicalHospital hospital)
        {
            _hospital = hospital;
        }

        public Appointment ScheduleAppointment(Patient patient, Doctor doctor, DateTime date, string reason)
        {
            var appointment = new Appointment
            {
                Id = GenerateAppointmentId(),
                Patient = patient,
                Doctor = doctor,
                AppointmentDate = date,
                Reason = reason,
                Status = AppointmentStatus.Scheduled
            };

            patient.Appointments.Add(appointment);
            doctor.Appointments.Add(appointment);

            return appointment;
        }

        public void CompleteAppointment(Appointment appointment, string diagnosis, string treatment)
        {
            appointment.Status = AppointmentStatus.Completed;

            var record = new MedicalRecord
            {
                Id = appointment.Patient.MedicalHistory.Count + 1,
                Diagnosis = diagnosis,
                Treatment = treatment,
                AttendingDoctor = appointment.Doctor
            };

            appointment.Patient.MedicalHistory.Add(record);
        }

        private int GenerateAppointmentId()
        {
            return _hospital.Doctors.SelectMany(d => d.Appointments).Count() + 1;
        }
    }
}