/***********************************************************************
 * Module:  Korisnik.cs
 * Author:  Dragan
 * Purpose: Definition of the Class UnregisteredUser
 ***********************************************************************/

using Hospital.Model.Abstract;
using System;

namespace Hospital.Model
{
    public class UnregisteredUser : IIdentifiable<long>
    {
        public Appointment appointment;
        public City city;

        public String Name { get; set; }
        public String Surname { get; set; }
        public long Jmbg { get; set; }
        public long Id { get; set; }
        public String Adrdess { get; set; }
        public long PhoneNumber { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public UnregisteredUser() { }
        public UnregisteredUser(long id)
        {
            Id = id;
        }

        public UnregisteredUser(string name, string surname, long jmbg, string adrdess, long phoneNumber, long id)
        {
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            Id = id;
            Adrdess = adrdess;
            PhoneNumber = phoneNumber;
        }
        public UnregisteredUser(string name, string surname, long jmbg,string adrdess, long phoneNumber)
        {
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            Adrdess = adrdess;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return Name + " " + Surname + " (" + Jmbg + ")";
        }
    }
}