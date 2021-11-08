using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.CSV.Converter
{
    class MedicationConverter: ICSVConverter<Medication>
    {
        private readonly string _delimiter;


        public MedicationConverter(string delimiter)
        {
            _delimiter = delimiter;
            
        }


        public Medication ConvertCSVFormatToEntity(string medicationCSVFormat)
        {
            string[] tokens = medicationCSVFormat.Split(_delimiter.ToCharArray());
            return new Medication(

                tokens[1],
                long.Parse(tokens[0]),
                Boolean.Parse(tokens[2]),
                tokens[3],
                int.Parse(tokens[4]),
                int.Parse(tokens[5]),
                int.Parse(tokens[6]),
                Boolean.Parse(tokens[7]),
                tokens[8]);
        }

        public string ConvertEntityToCSVFormat(Medication medication)
        => string.Join(_delimiter,
            medication.Id,
            medication.Name,
            medication.Approved,
            medication.Code,
            medication.Quantity,
            medication.NumberOfDoctrosApproved,
            medication.NumberOfDoctorsNotApproved,
            medication.ForApproval,
            medication.Alternative);



    }
}
