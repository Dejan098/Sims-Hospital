/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class PatientRepository : CSVRepository<Patient, long>, IPatientRepository
    {
        private const string ENTITY_NAME = "Patient";

        public PatientRepository(ICSVStream<Patient> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer) { }

        public Patient GetPatient()
        {
            // TODO: implement
            return null;
        }
        public Patient GetByUsernameAndPassword(string username, string password)
        {
            return _stream
                .ReadAll()
                .SingleOrDefault(entity => entity.Username == username & entity.Password == password);
                
        }

        public Patient GetByUsername(string username)
        {
            return _stream
                .ReadAll()
                .SingleOrDefault(entity => entity.Username == username);
        }

        public IEnumerable<Patient> GetByNameSurnameUsernameAndId(string name, string surname, string username, long id)
        => Find(patient => name == "" ? true : patient.Name == name
           && surname == "" ? true : patient.Surname == surname);
           // && username == "" ? true : patient.Username == username
           // && id == 0 ? true : patient.Id == id);

    }
}