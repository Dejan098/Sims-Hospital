/***********************************************************************
 * Module:  Upravnik.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Director
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Director : Staff
    {
        public Warehouse warehouse;

        public Director(long Id) : base(Id) { }
    }
}