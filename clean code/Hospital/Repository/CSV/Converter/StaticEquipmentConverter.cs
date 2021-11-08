using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.CSV.Converter
{
    class StaticEquipmentConverter : ICSVConverter<StaticEquipment>
    {

        private readonly string _delimiter;
        

        public StaticEquipmentConverter(string delimiter)
        {
            _delimiter = delimiter;
           
        }

        public string ConvertEntityToCSVFormat(StaticEquipment staticEquipment)
         => string.Join(_delimiter,
             staticEquipment.Id,
             staticEquipment.room,
             staticEquipment.Name);


        public StaticEquipment ConvertCSVFormatToEntity(string staticEquipmentCSVFormat)
        {
            string[] tokens = staticEquipmentCSVFormat.Split(_delimiter.ToCharArray());
            return new StaticEquipment(
                long.Parse(tokens[0]),
                tokens[2],
                new Room(long.Parse(tokens[1])));
                



        }
    }
}
