/***********************************************************************
 * Module:  StatickaOprema.cs
 * Author:  babic
 * Purpose: Definition of the Class StaticEquipment
 ***********************************************************************/

using Hospital.Model.Abstract;
using System;

namespace Hospital.Model
{
    public class StaticEquipment : IIdentifiable<long>
    {
        

        public long Id { get; set; }
        public string Name { get; set; }

        public Room room { get; set; }

        public StaticEquipment(long id)
        {
            Id = id;
        }

        public StaticEquipment(long id, string name, Room room1)
        {
            Id = id;
            Name = name;
            room = room1;

        }

        public StaticEquipment(string name)
        {
            Name = name;
        }
        

        
        public long GetId() => Id;
        public void SetId(long id) => Id = id;

    }
}