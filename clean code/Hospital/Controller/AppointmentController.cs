
using Hospital.Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class AppointmentController : IController<Appointment, long>
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentController() { }

        public AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public Model.Appointment ScheduleAppointment(Appointment appointment, string strategy) => _appointmentService.ScheduleAppointment(appointment, strategy);
     

        public void Update(Appointment appointment) => _appointmentService.Update(appointment);

        public IEnumerable<Appointment> GetFreeAppointments(DateTime from, DateTime thru, Doctor doctor, List<Appointment> takenAppointments) =>
            _appointmentService.GetFreeAppointments(from, thru, doctor, takenAppointments);

        public Appointment CreateAppointments(Appointment appointment) => _appointmentService.CreateAppointments(appointment);

        //public void GetDoctorsScheduledAppointments(Doctor doctor) => _appointmentService.getDoctorsScheduledAppointments(doctor);

        /*public Model.Appointment SetPriority(Doctor doctor, DateTime dateTimeBegin, DateTime dateTimeEnd)
        {
            // TODO: implement
            return null;
        }*/
        
        public IEnumerable<Appointment> GetAll() => _appointmentService.GetAll();

        public IEnumerable<Appointment> GetByRoomId(long id) => _appointmentService.GetByRoomId(id);
        public IEnumerable<Appointment> GetAllDoctorsAppointment(long id) => _appointmentService.GetAllDoctorsAppointment(id);

        public Appointment Get(long id) => _appointmentService.Get(id);

        public void Delete(Appointment appointment) => _appointmentService.Delete(appointment);
    }
}
