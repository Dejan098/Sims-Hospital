/***********************************************************************
 * Module:  MedicationController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.MedicationController
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
    public class MedicationRepository : CSVRepository<Medication, long>, IMedicationRepository
    {
        private const string ENTITY_NAME = "Medication";

        public MedicationRepository(ICSVStream<Medication> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer) { }

        public Medication GetMedication()
        {
            // TODO: implement
            return null;
        }


        public Medication FindById(int id)
        {
            // TODO: implement
            return null;
        }

        public Medication FindByCode(String code)
        {
            // TODO: implement
            return null;
        }

        public Medication FindByName(String name)
        => _stream.ReadAll().SingleOrDefault(medication => medication.Name.Equals(name));

        public IEnumerable<Medication> GetForApproval()
        => Find(medication => medication.ForApproval == true);

        public IEnumerable<Medication> GetApproved(bool approved)
        => Find(medication => medication.Approved == approved);

        public IEnumerable<Medication> notApproved()
        => Find(medication => medication.ForApproval ==true);
    }
}