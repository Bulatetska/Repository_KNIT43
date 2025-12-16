using System;
using Hospital.Core.Models;

namespace Hospital.Core.Services
{
    public class PatientService
    {
        private MedicalHospital _hospital;

        public PatientService(MedicalHospital hospital)
        {
            _hospital = hospital;
        }

        public Patient RegisterPatient(string firstName, string lastName, string phone, string email)
        {
            var patient = new Patient
            {
                Id = _hospital.Patients.Count + 1,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Email = email,
                MedicalCardNumber = GenerateMedicalCardNumber()
            };

            _hospital.AddPatient(patient);
            return patient;
        }

        private string GenerateMedicalCardNumber()
        {
            return $"MC{DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}