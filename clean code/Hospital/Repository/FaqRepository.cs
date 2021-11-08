/***********************************************************************
 * Module:  FAQController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.FAQController
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
    public class FaqRepository : CSVRepository<Faq, long>, IFaqRepository
    {
        private const string ENTITY_NAME = "Faq";
        private readonly CSVRepository<Patient, long> _patientRepository;

        public FaqRepository(ICSVStream<Faq> stream, ISequencer<long> sequencer, CSVRepository<Patient, long> patientRepository) 
            : base(ENTITY_NAME, stream, sequencer)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Faq> GetAllFaqsAnswered()
            => Find(faq => faq.Answer != "");

        public IEnumerable<Faq> GetAllFaqsNotAnswered()
        {
            IEnumerable<Patient> patients = _patientRepository.GetAll();
            IEnumerable<Faq> faqs = Find(faq => faq.Answer == "");
            BindPatientsWithFaqs(patients, faqs);
            return faqs;
        }

        private void BindPatientsWithFaqs(IEnumerable<Patient> patients, IEnumerable<Faq> faqs)
            => faqs.ToList().ForEach(faq => faq.Patient = FindPatientById(patients, faq.Patient.Id));

        private Patient FindPatientById(IEnumerable<Patient> patients, long id)
            => patients.SingleOrDefault(patient => patient.Id == id);
    }
}