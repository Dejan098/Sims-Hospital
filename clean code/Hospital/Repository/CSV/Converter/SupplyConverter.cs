using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.CSV.Converter
{
    class SupplyConverter : ICSVConverter<Supplies>
    {
        private readonly string _delimiter;

        public SupplyConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Supplies supplies)
            => string.Join(_delimiter,
                supplies.Id,
                supplies.Quantity,
                supplies.Name);


        public Supplies ConvertCSVFormatToEntity(string staffCSVFormat)
        {
            string[] tokens = staffCSVFormat.Split(_delimiter.ToCharArray());
            return new Supplies(
                long.Parse(tokens[0]),
                tokens[2],
                long.Parse(tokens[1])
                );

        }





    }
}
