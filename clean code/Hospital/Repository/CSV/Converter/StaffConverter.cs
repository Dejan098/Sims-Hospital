using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.CSV.Converter
{
    class StaffConverter : ICSVConverter<Staff>
    {
        private readonly string _delimiter;

        public StaffConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Staff staff)
          => string.Join(_delimiter,
              staff.Name,
              staff.Surname,
              staff.Jmbg,
              staff.Adrdess,
              staff.PhoneNumber,
              staff.Username,
              staff.Password,
              staff.Salary,
              staff.Role,
              staff.Id);

        public Staff ConvertCSVFormatToEntity(string staffCSVFormat)
        {
            string[] tokens = staffCSVFormat.Split(_delimiter.ToCharArray());
            return new Staff(
                tokens[0],
                tokens[1],
                long.Parse(tokens[2]),
                tokens[3],
                long.Parse(tokens[4]),
                tokens[5],
                tokens[6],
                double.Parse(tokens[7]),
                tokens[8],
                long.Parse(tokens[9]));
        }
    }
}
