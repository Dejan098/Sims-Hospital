/***********************************************************************
 * Module:  AppointmentService.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Service.AppointmentService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AppointmentRepository : CSVRepository<Appointment, long>, IAppointmentRepository
    {

        private const string ENTITY_NAME = "Appointment";
        private readonly CSVRepository<Patient, long> _patientRepository;
        private readonly StaffRepository _staffRepository;
        private readonly CSVRepository<Room, long> _roomRepository;


        public AppointmentRepository(ICSVStream<Appointment> stream, ISequencer<long> sequencer,
            CSVRepository<Patient, long> patientRepository, StaffRepository staffRepository, CSVRepository<Room, long> roomRepository)
            : base(ENTITY_NAME, stream, sequencer)
        {
            _patientRepository = patientRepository;
            _staffRepository = staffRepository;
            _roomRepository = roomRepository;
        }

        public IEnumerable<Appointment> GetAllApppointments()
        {
            IEnumerable<Patient> patients = _patientRepository.GetAll();
            IEnumerable<Staff> staffList = _staffRepository.GetAllDoctors();
            List<Doctor> doctors = new List<Doctor>();
            foreach (Staff staff in staffList)
            {
                Doctor doctor = new Doctor(staff.Name, staff.Surname, staff.Jmbg, staff.Adrdess, staff.PhoneNumber, staff.Username, staff.Password, staff.Salary, staff.Role, staff.Id);
                doctors.Add(doctor);
            }

            IEnumerable<Room> rooms = _roomRepository.GetAll();
            IEnumerable<Appointment> appointments = GetAll();
            BindPatientsDoctorsAndRoomsWithAppointments(patients, rooms, doctors, appointments);
            return appointments;
        }

        public IEnumerable<Appointment> GetAllDoctorsApppointments(long id)
        {
            Find(doctor => doctor.Id == id);
            IEnumerable<Patient> patients = _patientRepository.GetAll();
            IEnumerable<Room> rooms = _roomRepository.GetAll();
            IEnumerable<Appointment> appointments = GetAll();
            BindPatientsAndRoomsWithAppointments(patients, rooms, appointments);
            return appointments;
        }

        public Appointment FindByRoom(Room room)
        {
            // TODO: implement
            return null;
        }

        public Appointment FindByDoctor(Doctor doctor)
        {
            // TODO: implement
            return null;
        }

        public Appointment FindByPatient(Patient patient)
        {
            // TODO: implement
            return null;
        }

        public Appointment FindById(int id)
        {
            // TODO: implement
            return null;
        }

        public Appointment FindByDateTimeStart(DateTime start)
        {
            // TODO: implement
            return null;
        }

        public Appointment FindByDateTimeEnd(DateTime end)
        {
            // TODO: implement
            return null;
        }

        public Appointment FindByType(TypeOfRoom type)
        {
            // TODO: implement
            return null;
        }

        public IEnumerable<Appointment> GetByRoomId(long id)
        
            => Find(appointment=> appointment.Room.Id==id);


        

        private void BindPatientsDoctorsAndRoomsWithAppointments(IEnumerable<Patient> patients, IEnumerable<Room> rooms, IEnumerable<Doctor> doctors,
            IEnumerable<Appointment> appointments)
        { 
            appointments.ToList().ForEach(appointment => appointment.Patient = FindPatientById(patients, appointment.Patient.Id));
            appointments.ToList().ForEach(appointment => appointment.Doctor = FindDoctorById(doctors, appointment.Doctor.Id));
            appointments.ToList().ForEach(appointment => appointment.Room = FindRoomById(rooms, appointment.Room.Id));
        }

        private void BindPatientsAndRoomsWithAppointments(IEnumerable<Patient> patients, IEnumerable<Room> rooms,
            IEnumerable<Appointment> appointments)
        {
            appointments.ToList().ForEach(appointment => appointment.Patient = FindPatientById(patients, appointment.Patient.Id));
            appointments.ToList().ForEach(appointment => appointment.Room = FindRoomById(rooms, appointment.Room.Id));
        }

        private Patient FindPatientById(IEnumerable<Patient> patients, long id)
            => patients.SingleOrDefault(patient => patient.Id == id);
        private Doctor FindDoctorById(IEnumerable<Doctor> doctors, long id)
           => doctors.SingleOrDefault(doctor => doctor.Id == id);
        private Room FindRoomById(IEnumerable<Room> rooms, long id)
           => rooms.SingleOrDefault(room => room.Id == id);

    }
}