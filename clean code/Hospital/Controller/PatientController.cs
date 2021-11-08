/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using Hospital.Model;
using Service;

namespace Hospital.Controller
{
    public class PatientController : IController<Patient, long>
    {
        private PatientService _service;

        public PatientController() { }


        public PatientController(PatientService service)
        {
            _service = service;
        }

        public void ReportOnMedicalTreatment(Medication medications, Appointment appointments)
        {
            // TODO: implement
        }

        public Patient RegisterPatient(Patient patient) => _service.RegisterPatient(patient);

        public void UpdatePatient(Patient patient) => _service.UpdatePatient(patient);

        public Patient getByUsernameAndPassword(string username, string password) => _service.getByUsernameAndPassword(username, password);

        public IEnumerable<Patient> GetByNameSurnameUsernameAndId(string name, string surname, string username, long id)
            => _service.GetByNameSurnameUsernameAndId(name, surname, username, id);

        public void GetDoctorsPatients(Doctor doctor) => _service.GetDoctorsPatients(doctor);

        public IEnumerable<Patient> GetAll() => _service.GetAll();

        public Patient Get(long id) => _service.Get(id);
    }
}