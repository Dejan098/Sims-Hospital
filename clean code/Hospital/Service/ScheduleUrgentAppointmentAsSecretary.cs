/***********************************************************************
 * Module:  ScheduleUrgentAppointmentAsSecretary.cs
 * Author:  Hp EliteBook 840 G1
 * Purpose: Definition of the Class Model.ScheduleUrgentAppointmentAsSecretary
 ***********************************************************************/

using Hospital;
using Hospital.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace Service
{
    public class ScheduleUrgentAppointmentAsSecretary : ScheduleAppointmentStrategy
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly NotificationRepository _notificationRepository;

        public ScheduleUrgentAppointmentAsSecretary(AppointmentRepository appointmentRepository, NotificationRepository notificationRepository)
        {
            _appointmentRepository = appointmentRepository;
            _notificationRepository = notificationRepository;
        }

        public void MoveAppointmentsForDoctor(Appointment appointment)
        {
            List<Appointment> takenAppointments = _appointmentRepository.GetAll().ToList();
            TimeSpan duration = appointment.EndOfAppointment - appointment.BeginningOfAppointment;
            foreach (Appointment takenAppointment in takenAppointments)
            {
                if (takenAppointment.BeginningOfAppointment >= appointment.BeginningOfAppointment &&
                    takenAppointment.EndOfAppointment <= appointment.EndOfAppointment && takenAppointment.Doctor == appointment.Doctor)
                {
                    takenAppointment.BeginningOfAppointment.Add(duration);
                    takenAppointment.EndOfAppointment.Add(duration);
                    _appointmentRepository.Update(takenAppointment);
                }
            }
        }

        public void MoveAppointmentsInRoom(Appointment appointment)
        {
            List<Appointment> takenAppointments = _appointmentRepository.GetAll().ToList();
            TimeSpan duration = appointment.EndOfAppointment - appointment.BeginningOfAppointment;
            foreach (Appointment takenAppointment in takenAppointments)
            {
                if (takenAppointment.BeginningOfAppointment >= appointment.BeginningOfAppointment &&
                    takenAppointment.EndOfAppointment <= appointment.EndOfAppointment && takenAppointment.Room == appointment.Room)
                {
                    takenAppointment.BeginningOfAppointment.Add(duration);
                    takenAppointment.EndOfAppointment.Add(duration);
                    _appointmentRepository.Update(takenAppointment);
                }
            }
        }

        public Boolean isAppointmentFree(Appointment appointment)
        {
            List<Appointment> takenAppointments = _appointmentRepository.GetAll().ToList();
            foreach (Appointment takenAppointment in takenAppointments)
            {
                if (takenAppointment.BeginningOfAppointment >= appointment.BeginningOfAppointment &&
                    takenAppointment.EndOfAppointment <= appointment.EndOfAppointment && takenAppointment.Room == appointment.Room
                    && takenAppointment.Doctor == appointment.Doctor)
                {
                    return false;
                }
            }
            return true;
        }

        public Appointment ScheduleAppointment(Appointment appointment)
        {
            if(isAppointmentFree(appointment) == false)
            {
                if (appointment.BeginningOfAppointment == DateTime.Now)
                {
                    MessageBox.Show("Nemoguce je zakazati termin u ovom trenutku.");
                    return null;
                }
                else
                {
                    MoveAppointmentsForDoctor(appointment);
                    MoveAppointmentsInRoom(appointment);
                }
            }
           
            Appointment newAppointment = _appointmentRepository.Create(appointment);
            Notification notificationForDoctor = new Notification("Zakazan je Vaš novi termin: " + appointment.BeginningOfAppointment, appointment.Doctor.Id);
            Notification notificationForPatient = new Notification("Zakazan je Vaš novi termin: " + appointment.BeginningOfAppointment, appointment.Patient.Id);
            _notificationRepository.Create(notificationForDoctor);
            _notificationRepository.Create(notificationForPatient);

            return newAppointment;
        }
    }
}