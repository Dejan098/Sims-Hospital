using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.CSV.Converter
{
    class PatientConverter : ICSVConverter<Patient>
    {
        private readonly string _delimiter;

        public PatientConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Patient patient)
          => string.Join(_delimiter,
              patient.Name,
              patient.Surname,
              patient.Jmbg,
              patient.Id,
              patient.Adrdess,
              patient.PhoneNumber,
              patient.Username,
              patient.Password);

        public Patient ConvertCSVFormatToEntity(string patientCSVFormat)
        {
            string[] tokens = patientCSVFormat.Split(_delimiter.ToCharArray());
            return new Patient(
                tokens[0],
                tokens[1],
                long.Parse(tokens[2]),
                tokens[4],
                long.Parse(tokens[5]),
                tokens[6],
                tokens[7],
                long.Parse(tokens[3]));
        }
    }
}
