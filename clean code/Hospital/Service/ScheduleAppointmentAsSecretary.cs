/***********************************************************************
 * Module:  ScheduleAppointmentAsSecretary.cs
 * Author:  Hp EliteBook 840 G1
 * Purpose: Definition of the Class Model.ScheduleAppointmentAsSecretary
 ***********************************************************************/

using Hospital.Model;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ScheduleAppointmentAsSecretary : ScheduleAppointmentStrategy
    {

        private readonly AppointmentRepository _appointmentRepository;
        private readonly NotificationRepository _notificationRepository;

        public ScheduleAppointmentAsSecretary(AppointmentRepository appointmentRepository, NotificationRepository notificationRepository)
        {
            _appointmentRepository = appointmentRepository;
            _notificationRepository = notificationRepository;
        }


        public Appointment ScheduleAppointment(Appointment appointment)
        {
            Appointment newAppointment = _appointmentRepository.Create(appointment);
            Notification notificationForDoctor = new Notification("Zakazan je Vaš novi termin: " + appointment.BeginningOfAppointment, appointment.Doctor.Id);
            Notification notificationForPatient = new Notification("Zakazan je Vaš novi termin: " + appointment.BeginningOfAppointment, appointment.Patient.Id);
            _notificationRepository.Create(notificationForDoctor);
            _notificationRepository.Create(notificationForPatient);

            return newAppointment;
        }
    }
}