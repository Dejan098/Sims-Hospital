/***********************************************************************
 * Module:  FAQController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.FAQController
 ***********************************************************************/

using Hospital.Controller;
using Hospital.Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Controller
{
    public class FaqController : IController<Faq, long>
    {
        private FaqService _service;

        public FaqController() { }

        public FaqController(FaqService service)
        {
            _service = service;
        }

        public void CreateQuestion(String question) => _service.CreateQuestion(question);

        public Faq AddFAQ(Faq newFAQ) => _service.AddFAQ(newFAQ);

        public Faq AnswerFaq(Faq newFAQ) => _service.AnswerFaq(newFAQ);

        public IEnumerable<Faq> getAllFaqsAnswered() => _service.GetAllFaqsAnswered();

        public IEnumerable<Faq> getAllFaqsNotAnswered() => _service.GetAllFaqsNotAnswered();

        public IEnumerable<Faq> GetAll() => _service.GetAll();

        public Faq Get(long id) => _service.Get(id);

        public void Delete(Faq faq) => _service.Delete(faq);
    }   
}