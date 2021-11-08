using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   
    public class FeedbackRepository : CSVRepository<Feedback, long>, IFeedbackRepository
    {
        private const string ENTITY_NAME = "Feedback";
        private readonly CSVRepository<Patient, long> _patientRepository;

        public FeedbackRepository(ICSVStream<Feedback> stream, ISequencer<long> sequencer, CSVRepository<Patient, long> patientRepository) 
            : base(ENTITY_NAME, stream, sequencer)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Feedback> GetAllFeedback()
             => Find(feedback => feedback.isBug == false);

        public IEnumerable<Feedback> GetAllBugs()
             => Find(feedback => feedback.isBug == true);

        /*private void BindUsersWithFeedback(IEnumerable<RegisteredUser> patients, IEnumerable<Feedback> feedback)
           => faqs.ToList().ForEach(faq => faq.Patient = FindPatientById(patients, faq.Patient.Id));

        private Patient FindPatientById(IEnumerable<Patient> patients, long id)
            => patients.SingleOrDefault(patient => patient.Id == id);*/

    }
}
