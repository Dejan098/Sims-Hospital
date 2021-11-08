/***********************************************************************
 * Module:  Doktor.cs
 * Author:  babic
 * Purpose: Definition of the Class Doctor
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Doctor : Staff
    { 

        public System.Collections.ArrayList patient;

        public Doctor(long Id) : base(Id) { }

        public Doctor(string name, string surname, long jmbg, string adrdess, long phoneNumber, string username, string password, double salary, string role, long id)
           : base(name, surname, jmbg, adrdess, phoneNumber, username, password, salary, role, id) { }

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetPatient()
        {
            if (patient == null)
                patient = new System.Collections.ArrayList();
            return patient;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetPatient(System.Collections.ArrayList newPatient)
        {
            RemoveAllPatient();
            foreach (Patient oPatient in newPatient)
                AddPatient(oPatient);
        }

        public Doctor()
        {

        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddPatient(Patient newPatient)
        {
            if (newPatient == null)
                return;
            if (this.patient == null)
                this.patient = new System.Collections.ArrayList();
            if (!this.patient.Contains(newPatient))
                this.patient.Add(newPatient);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemovePatient(Patient oldPatient)
        {
            if (oldPatient == null)
                return;
            if (this.patient != null)
                if (this.patient.Contains(oldPatient))
                    this.patient.Remove(oldPatient);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllPatient()
        {
            if (patient != null)
                patient.Clear();
        }
        public System.Collections.ArrayList appointment;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetAppointment()
        {
            if (appointment == null)
                appointment = new System.Collections.ArrayList();
            return appointment;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetAppointment(System.Collections.ArrayList newAppointment)
        {
            RemoveAllAppointment();
            foreach (Appointment oAppointment in newAppointment)
                AddAppointment(oAppointment);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointment == null)
                this.appointment = new System.Collections.ArrayList();
            if (!this.appointment.Contains(newAppointment))
            {
                this.appointment.Add(newAppointment);
                newAppointment.SetDoctor(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointment != null)
                if (this.appointment.Contains(oldAppointment))
                {
                    this.appointment.Remove(oldAppointment);
                    oldAppointment.SetDoctor((Doctor)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllAppointment()
        {
            if (appointment != null)
            {
                System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in appointment)
                    tmpAppointment.Add(oldAppointment);
                appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.SetDoctor((Doctor)null);
                tmpAppointment.Clear();
            }
        }

    }
}