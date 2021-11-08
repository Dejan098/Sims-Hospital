/***********************************************************************
 * Module:  PotrosnaOprema.cs
 * Author:  babic
 * Purpose: Definition of the Class Supplies
 ***********************************************************************/

using Hospital.Model.Abstract;
using System;

namespace Hospital.Model
{
    public class Supplies : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
       
       

        public Supplies(long id, string name, long quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            
        }

        public long GetId() => Id;
        public void SetId(long id) => Id = id;

    }
}