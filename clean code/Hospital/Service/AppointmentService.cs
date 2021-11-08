/***********************************************************************
 * Module:  AppointmentService.cs
 * Author:  Hp EliteBook 840 G1
 * Purpose: Definition of the Class Service.AppointmentService
 ***********************************************************************/

using Hospital;
using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class AppointmentService:IService<Appointment, long>
    {
        private readonly AppointmentRepository _repository;
        public ScheduleAppointmentStrategy scheduleAppointmentStrategy;
        public ScheduleAppointmentAsSecretary _scheduleAppointmentAsSecretary;
        public ScheduleAppointmentAsPatient _scheduleAppointmentAsPatient;
        public ScheduleCheckUpAppointmentAsDoctor _scheduleCheckUpAppointmentAsDoctor;
        public ScheduleOperationAsDoctor _scheduleOperationAsDoctor;
        public ScheduleReferralAppointmentAsDoctor _scheduleReferralAppointmentAsDoctor;
        public ScheduleUrgentAppointmentAsSecretary _scheduleUrgentAppointmentAsSecretary;

        public AppointmentService(AppointmentRepository repository, ScheduleAppointmentAsSecretary scheduleAppointmentAsSecretary, ScheduleAppointmentAsPatient scheduleAppointmentAsPatient,
            ScheduleCheckUpAppointmentAsDoctor scheduleCheckUpAppointmentAsDoctor, ScheduleOperationAsDoctor scheduleOperationAsDoctor,
            ScheduleReferralAppointmentAsDoctor scheduleReferralAppointmentAsDoctor, ScheduleUrgentAppointmentAsSecretary scheduleUrgentAppointmentAsSecretary)
        {
            _repository = repository;
            _scheduleAppointmentAsSecretary = scheduleAppointmentAsSecretary;
            _scheduleAppointmentAsPatient = scheduleAppointmentAsPatient;
            _scheduleCheckUpAppointmentAsDoctor = scheduleCheckUpAppointmentAsDoctor;
            _scheduleOperationAsDoctor = scheduleOperationAsDoctor;
            _scheduleReferralAppointmentAsDoctor = scheduleReferralAppointmentAsDoctor;
            _scheduleUrgentAppointmentAsSecretary = scheduleUrgentAppointmentAsSecretary;
        }

        public Appointment CreateAppointments(Appointment appointment)
        {
            // TODO: implement
            Appointment newappointment;
            newappointment = _repository.Create(appointment);
            // TODO: implement
            return newappointment;
            
        }

        public void Update(Appointment appointment) => _repository.Update(appointment);
        public Appointment ScheduleAppointment(Appointment appointment, string strategy)
        {
            switch (strategy)
            {
                case "secretary":
                    _scheduleAppointmentAsSecretary.ScheduleAppointment(appointment);
                    break;
                case "patient":
                    _scheduleAppointmentAsPatient.ScheduleAppointment(appointment);
                    break;
                case "checkup":
                    _scheduleCheckUpAppointmentAsDoctor.ScheduleAppointment(appointment);
                    break;
                case "operation":
                    _scheduleOperationAsDoctor.ScheduleAppointment(appointment);
                    break;
                case "referral":
                    _scheduleReferralAppointmentAsDoctor.ScheduleAppointment(appointment);
                    break;
                case "urgent":
                    _scheduleUrgentAppointmentAsSecretary.ScheduleAppointment(appointment);
                    break;
            }

            return appointment;
        }

        public IEnumerable<Appointment> GetByRoomId(long id)
        {
            return _repository.GetByRoomId(id);
        }

        public Appointment SetPriority(Doctor doctor, DateTime dateTimeBegin, DateTime dateTimeEnd)
        {
            // TODO: implement
            return null;
        }

        public IEnumerable<DateTime> EveryTwentyMinutes(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddMinutes(20))
            {
                yield return day;
            }
        }

        public IEnumerable<Appointment> GetFreeAppointments(DateTime from, DateTime thru, Doctor doctor, List<Appointment> takenAppointments)
        {
            List<Appointment> freeAppointments = new List<Appointment>();
            foreach (DateTime day in EveryTwentyMinutes(from, thru))
            {
                Appointment appointment = new Appointment(day, day.AddMinutes(20), doctor);
                freeAppointments.Add(appointment);
                foreach (Appointment takenAppointment in takenAppointments)
                {
                    if (takenAppointment.BeginningOfAppointment >= appointment.BeginningOfAppointment && 
                        takenAppointment.EndOfAppointment <= appointment.EndOfAppointment)
                    {
                        freeAppointments.Remove(appointment);
                    }
                }
            }

            return freeAppointments;
        }

        public Appointment Get(long id) => _repository.Get(id);

        
        public IEnumerable<Appointment> GetAllDoctorsAppointment(long id)
        {
            var appointments = _repository.GetAllDoctorsApppointments(id);
            return appointments;
        }
        public IEnumerable<Appointment> GetAll()
        {
            var appointments = _repository.GetAllApppointments();
            return appointments;
        }

        public void Delete(Appointment appointment) => _repository.Delete(appointment);
    }
}