using Hospital.Model;
using Hospital.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hospital.Service
{
    public class FeedbackService : IService<Feedback, long>
    {
        private readonly FeedbackRepository _repository;

        public FeedbackService(FeedbackRepository repository)
        {
            _repository = repository;
        }

        public Feedback AddFeedback(Feedback newFeedback)
        {
            //Add Faq in csv file or add only question of Faq in csv file
            Feedback newFeedback2;
            newFeedback2 = _repository.Create(newFeedback);
            return newFeedback2;
        }

        public Feedback Get(long id) => _repository.Get(id);

        public IEnumerable<Feedback> GetAll() => _repository.GetAll();

        public IEnumerable<Feedback> GetAllFeedback() => _repository.GetAllFeedback();

        public IEnumerable<Feedback> GetAllBugs() => _repository.GetAllBugs();

        public void Delete(Feedback feedback) => _repository.Delete(feedback);
        
    }
}
