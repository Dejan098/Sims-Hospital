/***********************************************************************
 * Module:  Prostorija.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Room
 ***********************************************************************/

using Hospital.Model.Abstract;
using System;

namespace Hospital.Model
{
    public class Room : IIdentifiable<long>
    {
        public StaticEquipment[] staticEquipment;

        public long Id { get; set; }
        public string Type { get; set; }
        
        public DateTime BeginningOfRoomOccupancy { get; set; }
        public DateTime EndOfRoomOccupancy { get; set; }

        public long GetId() => Id;
        public void SetId(long id) => Id = id;

       public Room() { }

        public override string ToString()
        {
            return Id+"";
        }

        public Room(long id, string type, DateTime begin, DateTime end)
        {
            Id = id;
            Type = type;
            BeginningOfRoomOccupancy = begin;
            EndOfRoomOccupancy = end;
        }

        public Room(long id, string type)
        {
            Id = id;
            Type = type;
          
        }

        public Room(long id)
        {
            Id = id;
        }
    }
}