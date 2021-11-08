/***********************************************************************
 * Module:  ScheduleAppointmentAsSecretary.cs
 * Author:  Hp EliteBook 840 G1
 * Purpose: Definition of the Class Model.ScheduleAppointmentAsSecretary
 ***********************************************************************/

using Hospital.Model;
using Repository;
using System;

namespace Service
{
    public class ScheduleReferralAppointmentAsDoctor : ScheduleAppointmentStrategy
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly NotificationRepository _notificationRepository;

        public ScheduleReferralAppointmentAsDoctor(AppointmentRepository appointmentRepository, NotificationRepository notificationRepository)
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