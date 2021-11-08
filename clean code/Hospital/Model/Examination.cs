using Hospital.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Model
{
    public class Examination : IIdentifiable<long>
    {
        
        public long Id { get; set; }
        public string MedicationName { get; set; }
        public string MedicationDosage { get; set; }
        public long IdPatient { get; set; }
        public string Anamnesis { get; set; }

        public Examination(long id, string medicationName, string medicationDosage, long idPatient, string anamnesis)
        {
            Id = id;
            MedicationName = medicationName;
            MedicationDosage = medicationDosage;
            IdPatient = idPatient;
            Anamnesis = anamnesis;
        }

        public Examination()
        {
           
        }


        public long GetId()
        {
            return Id;

        }

        public void SetId(long id)
         => Id = id;
    }
}
