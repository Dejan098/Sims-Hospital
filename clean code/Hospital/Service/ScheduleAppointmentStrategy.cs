/***********************************************************************
 * Module:  ScheduleAppointmentStrategy.cs
 * Author:  Hp EliteBook 840 G1
 * Purpose: Definition of the Interface Model.ScheduleAppointmentStrategy
 ***********************************************************************/

using Hospital.Model;
using System;

namespace Service
{
    public interface ScheduleAppointmentStrategy
    {
        Appointment ScheduleAppointment(Appointment appointment);
    }
}