/***********************************************************************
 * Module:  ScheduleAppointmentAsPatient.cs
 * Author:  Hp EliteBook 840 G1
 * Purpose: Definition of the Class Model.ScheduleAppointmentAsPatient
 ***********************************************************************/

using Hospital.Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ScheduleAppointmentAsPatient : ScheduleAppointmentStrategy
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly NotificationRepository _notificationRepository;

        public ScheduleAppointmentAsPatient(AppointmentRepository appointmentRepository, NotificationRepository notificationRepository)
        {
            _appointmentRepository = appointmentRepository;
            _notificationRepository = notificationRepository;
        }

        public Appointment ScheduleAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}