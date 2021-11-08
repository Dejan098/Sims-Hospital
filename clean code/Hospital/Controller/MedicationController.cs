/***********************************************************************
 * Module:  MedicationController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.MedicationController
 ***********************************************************************/

using Hospital.Controller;
using Hospital.Model;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Controller
{
    public class MedicationController : IController<Medication, long>
    {
        private readonly MedicationService _service;

        public MedicationController(MedicationService service)
        {
            _service = service;
        }

        public Medication RegisterMedication(Medication medication) => _service.RegisterMedication(medication);

        public void ApproveMedication(Medication medication) => _service.ApproveMedication(medication);

        public void DeclineMedication(Medication medication) => _service.DeclineMedication(medication);

        public void OrderMedication(Medication medication, int quantity) => _service.OrderMedication(medication, quantity);


        public void DecreaseMedication(Medication medication, int quantity) => _service.DecreaseMedication(medication, quantity);

        public void AddAlternativeMedication(Medication declined, Medication alternative) => _service.AddAlternativeMedication(declined, alternative);


        public IEnumerable<Medication> GetForApproval()  => _service.GetForApproval();
        public IEnumerable<Medication> GetApproved(bool approved) => _service.GetApproved(approved);

        public IEnumerable<Medication> GetAll() => _service.GetAll();

        public Medication Get(long id) => _service.Get(id);

        public Medication GetByName(string name) => _service.GetByName(name);


    }
}