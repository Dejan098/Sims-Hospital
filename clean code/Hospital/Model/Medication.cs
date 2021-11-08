/***********************************************************************
 * Module:  Lek.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Medication
 ***********************************************************************/

using Hospital.Model.Abstract;
using System;

namespace Hospital.Model
{
    public class Medication : IIdentifiable<long>
    {
        public string Alternative{ get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        public Boolean Approved { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public int NumberOfDoctrosApproved { get; set; }
        public int NumberOfDoctorsNotApproved { get; set; }
        public Boolean ForApproval { get; set; }

       
        //Approved = false && ForApproval = true -lek ide na odobravanje
        //Approved = false && ForApproval = false -lek odbijen
        //Approved = true && ForApproval = false -lek odobren
        public Medication(string name, long id, bool approved, string code, int quantity, int numberOfDoctrosApproved, int numberOfDoctorsNotApproved, bool forApproval, string alternative)
        {
           
            Name = name;
            Id = id;
            Approved = approved;
            Code = code;
            Quantity = quantity;
            NumberOfDoctrosApproved = numberOfDoctrosApproved;
            NumberOfDoctorsNotApproved = numberOfDoctorsNotApproved;
            ForApproval = forApproval;
            Alternative = alternative;
        }

        public Medication(long id,string name,string code)
        {
            Id = id;
            Name = name;
            Code = code;
            Quantity = 0;
            NumberOfDoctorsNotApproved = 0;
            NumberOfDoctrosApproved = 0;
            ForApproval = true;
            Approved = false;
            Alternative = "";
        }
        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}