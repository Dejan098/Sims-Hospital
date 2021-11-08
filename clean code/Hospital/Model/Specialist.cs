/***********************************************************************
 * Module:  Specijalista.cs
 * Author:  babic
 * Purpose: Definition of the Class Specialist
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Specialist : Doctor
    {
        public String Specialization;

        public Specialist(long Id) : base(Id) { }

    }
}