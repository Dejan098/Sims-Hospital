/***********************************************************************
 * Module:  IzvestajOPregleduPacijenta.cs
 * Author:  babic
 * Purpose: Definition of the Class Anamnesis
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    /// prepisiRecept - ukoliko lek nije iz zaliha bolnice
    public class Anamnesis
    {
        public Appointment appointment;
        public File file;

        public String Description;
        public String Prescription;

    }
}