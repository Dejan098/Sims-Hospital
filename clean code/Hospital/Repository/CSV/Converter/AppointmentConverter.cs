using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.CSV.Converter
{
    class AppointmentConverter : ICSVConverter<Appointment>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public AppointmentConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(Appointment appointment)
          => string.Join(_delimiter,
              appointment.Id,
              appointment.BeginningOfAppointment.ToString(_datetimeFormat),
              appointment.EndOfAppointment.ToString(_datetimeFormat),
              appointment.Type,
              appointment.IsFree,
              appointment.IsUrgent,
              appointment.Patient.Id,
              appointment.Doctor.Id,
              appointment.Room);

        public Appointment ConvertCSVFormatToEntity(string appointmentCSVFormat)
        {
            string[] tokens = appointmentCSVFormat.Split(_delimiter.ToCharArray());
            return new Appointment(
                long.Parse(tokens[0]),
                DateTime.Parse(tokens[1]),
                DateTime.Parse(tokens[2]),
                //Enum.Parse(typeof(AppointmentType), tokens[3]),
                tokens[3],
                Boolean.Parse(tokens[4]),
                Boolean.Parse(tokens[5]),
                new Patient(long.Parse(tokens[6])),
                new Room(long.Parse(tokens[8])),
                new Doctor(long.Parse(tokens[7])));
        }
    }
}
