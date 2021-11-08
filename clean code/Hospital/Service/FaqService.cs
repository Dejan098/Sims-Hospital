/***********************************************************************
 * Module:  FAQController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.FAQController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class FaqService:IService<Faq, long>
    {
        private readonly FaqRepository _repository;

        public FaqService(FaqRepository repository)
        {
            _repository = repository;
        }


        public void CreateQuestion(String question)
        {
            // TODO: implement
        }
        
        public Faq AddFAQ(Faq newFAQ)
        {
            //Add Faq in csv file or add only question of Faq in csv file
            Faq newFaq2;
            newFaq2 = _repository.Create(newFAQ);
            return newFaq2;
        }

        public Faq AnswerFaq(Faq newFAQ)
        {
            Faq faq = Get(newFAQ.Id);
            faq.Answer = newFAQ.Answer;
            _repository.Update(faq);
            return faq;
        }


        public Faq Get(long id) => _repository.Get(id);

        public IEnumerable<Faq> GetAllFaqsAnswered()
        {
            var faqs = _repository.GetAllFaqsAnswered();
            return faqs;
        }

        public IEnumerable<Faq> GetAllFaqsNotAnswered()
        {
            var faqs = _repository.GetAllFaqsNotAnswered();
            return faqs;
        }

        public IEnumerable<Faq> GetAll() => _repository.GetAll();

        public void Delete(Faq faq) => _repository.Delete(faq);

    }
}