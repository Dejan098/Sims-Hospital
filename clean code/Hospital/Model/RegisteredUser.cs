/***********************************************************************
 * Module:  RegistrovaniKorisnik.cs
 * Author:  Vanja
 * Purpose: Definition of the Class RegisteredUser
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class RegisteredUser : UnregisteredUser
    {
        public String Username { get; set; }
        public String Password { get; set; }
        //public int Id;

        public RegisteredUser(long Id) : base(Id) { }

        public RegisteredUser() : base() { }

        public RegisteredUser(string name, string surname, long jmbg, string adrdess, long phoneNumber, string username, string password, long id)
            : base(name, surname, jmbg, adrdess, phoneNumber, id)
        {
            Username = username;
            Password = password;
        }

        public RegisteredUser(string name, string surname, long jmbg, string adrdess, long phoneNumber, string username, string password)
           : base(name, surname, jmbg, adrdess, phoneNumber)
        {
            Username = username;
            Password = password;
        }


    }
}