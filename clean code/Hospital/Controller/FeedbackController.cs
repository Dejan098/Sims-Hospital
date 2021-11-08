using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Service;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Service;

namespace Hospital.Controller
{
    public class FeedbackController : IController<Feedback, long>
    {
        private readonly FeedbackService _feedbackService;

        public FeedbackController() { }

        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public Feedback AddFeedback(Feedback newFeedback) => _feedbackService.AddFeedback(newFeedback);

        public Feedback Get(long id) => _feedbackService.Get(id);

        public IEnumerable<Feedback> GetAllFeedback() => _feedbackService.GetAllFeedback();

        public IEnumerable<Feedback> GetAllBugs() => _feedbackService.GetAllBugs();

        public IEnumerable<Feedback> GetAll() => _feedbackService.GetAll();

        public void Delete(Feedback feedback) => _feedbackService.Delete(feedback);

    }
}
