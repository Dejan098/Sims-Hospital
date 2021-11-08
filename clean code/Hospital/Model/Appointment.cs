/***********************************************************************
 * Module:  Termin.cs
 * Author:  Dragan
 * Purpose: Definition of the Class Appointment
 ***********************************************************************/

using Hospital.Model.Abstract;
using System;

namespace Hospital.Model
{

    public enum AppointmentType
    {
        Operation,
        Examination,
        Checkup,
        Hospitalization
    }

    public class Appointment : IIdentifiable<long>
    {
        public long Id { get; set; }
        public DateTime BeginningOfAppointment { get; set; }
        public DateTime EndOfAppointment { get; set; }
        public string Type { get; set; }

        public Boolean IsFree = true;

        public Boolean IsUrgent = false;
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public Doctor Doctor { get; set; }

        public Appointment(long id, DateTime beginningOfAppointment, DateTime endOfAppointment, string type,
            bool isFree, bool isUrgent, Patient patient, Room room, Doctor doctor)
        {
            Id = id;
            BeginningOfAppointment = beginningOfAppointment;
            EndOfAppointment = endOfAppointment;
            Type = type;
            IsFree = isFree;
            IsUrgent = isUrgent;
            this.Patient = patient;
            this.Room = room;
            this.Doctor = doctor;
        }

        public Appointment(Room room, DateTime beginningOfAppointment, DateTime endOfAppointment)
        {
            Id = 6;
            Type = "Renovacija";
            IsFree = false;
            IsUrgent = false;
            Patient = new Patient();
            Room = Room;
            Doctor = new Doctor();
            BeginningOfAppointment = beginningOfAppointment;
            EndOfAppointment = endOfAppointment;
        }

        public Appointment(DateTime beginningOfAppointment, DateTime endOfAppointment, Doctor doctor)
        {   
            BeginningOfAppointment = beginningOfAppointment;
            EndOfAppointment = endOfAppointment;
            Doctor = doctor;
        }

        public Appointment(DateTime beginningOfAppointment, DateTime endOfAppointment)
        {
            BeginningOfAppointment = beginningOfAppointment;
            EndOfAppointment = endOfAppointment;
        }

        public Appointment(DateTime beginningOfAppointment, DateTime endOfAppointment, string type,
            bool isFree, bool isUrgent, Patient patient, Room room, Doctor doctor)
        {
            BeginningOfAppointment = beginningOfAppointment;
            EndOfAppointment = endOfAppointment;
            Type = type;
            IsFree = isFree;
            IsUrgent = isUrgent;
            this.Patient = patient;
            this.Room = room;
            this.Doctor = doctor;
        }

        public Appointment ScheduleAppointment()
        {
            // TODO: implement
            return null;
        }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Doctor GetDoctor()
        {
            return Doctor;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newDoctor</param>
        public void SetDoctor(Doctor newDoctor)
        {
            if (this.Doctor != newDoctor)
            {
                if (this.Doctor != null)
                {
                    Doctor oldDoctor = this.Doctor;
                    this.Doctor = null;
                    oldDoctor.RemoveAppointment(this);
                }
                if (newDoctor != null)
                {
                    this.Doctor = newDoctor;
                    this.Doctor.AddAppointment(this);
                }
            }
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

    }
}