/***********************************************************************
 * Module:  Karton.cs
 * Author:  babic
 * Purpose: Definition of the Class File
 ***********************************************************************/

using Hospital.Model.Abstract;
using System;

namespace Hospital.Model
{
    public class File : IIdentifiable<long>
    {
        public Anamnesis[] anamnesis;
        public Patient patient;

        public long Id;

        public long GetId() => Id;
        public void SetId(long id) => Id = id;
    }
}