/***********************************************************************
 * Module:  PatientService.cs
 * Author:  babic
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows;

namespace Service
{
    public class PatientService:IService<Patient, long>
    {
        private readonly PatientRepository _repository;

        public PatientService(PatientRepository repository)
        {
            _repository = repository;
        }

        public Patient getByUsernameAndPassword(string username, string password)
        {
            Patient patient = _repository.GetByUsernameAndPassword(username, password);
            if (patient == null)
            {
                MessageBox.Show("Pogresno korisnicko ime ili lozinka.");
            }
            return patient;
        }

        public IEnumerable<Patient> GetByNameSurnameUsernameAndId(string name, string surname, string username, long id)
        {
            IEnumerable<Patient> patients = _repository.GetByNameSurnameUsernameAndId(name, surname, username, id);
            if (patients == null)
            {
                MessageBox.Show("Pogresno korisnicko ime ili lozinka.");
            }
            return patients;
        }

        public void ReportOnMedicalTreatment(Medication medications, Appointment appointments)
        {
            // TODO: implement
        }

        public Patient RegisterPatient(Patient patient)
        {
            Patient newPatient;

            if (IsUsernameUnique(patient.Username) == true)
            {
                newPatient = _repository.Create(patient);
                return newPatient;
            }
            else
            {
                MessageBox.Show("Korisnicko ime mora biti jedinstveno!");
                return null;
            }
        }

        private bool IsUsernameUnique(string username)
        {
            if (_repository.GetByUsername(username) == null)
                return true;
            else
                return false;
        }

        public void UpdatePatient(Patient patient)
        {
            _repository.Update(patient);
        }

        //Ne znam zasto je null, promeniti
        public IEnumerable<Patient> GetDoctorsPatients(Doctor doctor) => null;

        public Patient Get(long id) => _repository.Get(id);

        public IEnumerable<Patient> GetAll()
        {
            var patients = _repository.GetAll();
            return patients;
        }

        /*public IEnumerable<Patient> GetByNameSurnameAndUsername(string name, string surname, string username)
        {
            var patients = _patientRepository.getByNameSurnameAndUsername(name, surname, username);
            return patients;
        }*/
    }
}