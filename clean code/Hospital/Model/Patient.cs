/***********************************************************************
 * Module:  Pacijent.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Patient
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Patient : RegisteredUser
    {
        public Appointment[] appointment;
        public File file;

        public Patient():base(){ }
        public Patient(long Id) : base(Id) { }

        public Patient(string name, string surname, long jmbg, string adrdess, long phoneNumber, string username, string password, long id)
            : base(name, surname, jmbg, adrdess, phoneNumber, username, password, id) { }

        public Patient(string name, string surname, long jmbg, string adrdess, long phoneNumber, string username, string password)
          : base(name, surname, jmbg, adrdess, phoneNumber, username, password) { }

    }
}