/***********************************************************************
 * Module:  Faq.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Faq
 ***********************************************************************/

using Hospital.Model.Abstract;
using System;

namespace Hospital.Model
{
    public class Faq : IIdentifiable<long>
    {
        public Patient Patient { get; set; }
        public String Question { get; set; }
        public long Id { get; set; }
        public String Answer { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public Faq(Patient patient, string question, long id, string answer)
        {
            Patient = patient;
            Question = question;
            Id = id;
            Answer = answer;
        }

        public Faq(Patient patient,string question)
        {
            Patient = patient;
            Question = question;
           
        }
    }
}