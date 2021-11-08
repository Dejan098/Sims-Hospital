/***********************************************************************
 * Module:  Zaposleni.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Staff
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Staff : RegisteredUser
    {
        public Hospital hospital;
        public WorkingHours workingHours;

        public double Salary { get; set; }
        public string Role { get; set; }

        public Staff(long Id) : base(Id) { }

        public Staff() { }

        public Staff(string name, string surname, long jmbg, string adrdess, long phoneNumber, string username, string password, double salary, string role, long id)
           : base(name, surname, jmbg, adrdess, phoneNumber, username, password, id)
        {
            Salary = salary;
            Role = role;
        }

    }
}