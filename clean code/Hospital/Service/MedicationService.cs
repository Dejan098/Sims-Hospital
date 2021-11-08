/***********************************************************************
 * Module:  MedicationController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.MedicationController
 ***********************************************************************/

using Hospital;
using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class MedicationService:IService<Medication, long>
    {
        private readonly MedicationRepository _repository;

        public MedicationService(MedicationRepository repository)
        {
            _repository = repository;
        }

        public void ApproveMedication(Medication medication)
        {
            approveMedicationAndSetFlags(medication);
            
            _repository.Update(medication);
        }

        private void approveMedicationAndSetFlags(Medication medication)
        {
            medication.NumberOfDoctrosApproved += 1;

            if (medication.NumberOfDoctrosApproved == 2)
            {
                medication.ForApproval = false;
                medication.Approved = true;
            }
        }

        public void DeclineMedication(Medication medication)
        {
            declineAndSetFlags(medication);
            _repository.Update(medication);

        }

        private void declineAndSetFlags(Medication medication)
        {
            medication.NumberOfDoctorsNotApproved += 1;
            medication.ForApproval = false;
            medication.Approved = false;
        }

        public void OrderMedication(Medication medication, int quantity)
        {
            medication.Quantity = medication.Quantity + quantity;
            _repository.Update(medication);
        }

        public void DecreaseMedication(Medication medication, int quantity)
        {
            // TODO: implement
        }

        public Medication RegisterMedication(Medication medication)
        {
            Medication newMedication;

            newMedication = _repository.Create(medication);
            return newMedication;
            
        }

        public void AddAlternativeMedication(Medication declined, Medication alternative)
        {
            // TODO: implement
            declined.Alternative = alternative.Code;
            _repository.Update(declined);
            

        }

        public Boolean CheckMedicationID(Medication medication)
        {
            // TODO: implement
            return false;
        }

        public Boolean IsMedicationRegistered()
        {
            // TODO: implement
            return false;
        }

        public Boolean IsMediationApproved()
        {
            // TODO: implement
            return false;
        }

        public IEnumerable<Medication> GetForApproval()
        {

            var medications = _repository.GetForApproval();
            return medications;

        }

        public IEnumerable<Medication> GetApproved(bool approved)
        {
            var medications = _repository.GetApproved(approved);
            return medications;
        }

        public Medication Get(long id) => _repository.Get(id);

        public Medication GetByName(string name) => _repository.FindByName(name);

        public IEnumerable<Medication> GetAll()
        {
            var medication = _repository.GetAll();
            return medication;
        }
    }
}