using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.CSV.Converter
{
    class RoomConverter: ICSVConverter<Room>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;
        public RoomConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;


        }


        public Room ConvertCSVFormatToEntity(string roomCSVFormat)
        {
            string[] tokens = roomCSVFormat.Split(_delimiter.ToCharArray());

            return new Room(
                long.Parse(tokens[0]),
                tokens[1],
                DateTime.Parse(tokens[2]),
                DateTime.Parse(tokens[3]));
                

        }

        public string ConvertEntityToCSVFormat(Room room)
         => string.Join(_delimiter,
             room.Id,
             room.Type,
             room.BeginningOfRoomOccupancy.ToString(_datetimeFormat),
             room.EndOfRoomOccupancy.ToString(_datetimeFormat));

    }
}
