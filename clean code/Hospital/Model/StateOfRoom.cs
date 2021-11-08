/***********************************************************************
 * Module:  StanjeProstorije.cs
 * Author:  Vanja
 * Purpose: Definition of the Class StateOfRoom
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    /// "U renovaciji" postoji zbog zakazivanja hitnih slucajeva.
    public class StateOfRoom
    {
        public Enum Occupied;
        public Enum Free;
        public Enum InRenovation;

    }
}