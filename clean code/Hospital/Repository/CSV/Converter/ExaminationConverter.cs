using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.CSV.Converter
{
    class ExaminationConverter : ICSVConverter<Examination>
    {
        private readonly string _delimiter;

        public ExaminationConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Examination ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Examination(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                long.Parse(tokens[3]),
                tokens[4]);
        }

        public string ConvertEntityToCSVFormat(Examination entity)
           => string.Join(_delimiter,
               entity.Id,
               entity.MedicationName,
               entity.MedicationDosage,
               entity.IdPatient,
               entity.Anamnesis);
        
    }
}
