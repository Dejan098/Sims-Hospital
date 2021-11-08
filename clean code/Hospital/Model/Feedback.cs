/***********************************************************************
 * Module:  PrijavaBagova.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Feedback
 ***********************************************************************/

using Hospital.Model.Abstract;
using System;

namespace Hospital.Model
{
    public class Feedback : IIdentifiable<long>
    {
        public RegisteredUser registeredUser { get; set; }

        public String Description { get; set; }
        public long Id { get; set; }
        public Boolean isBug { get; set; }
        
        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public Feedback(long id, string desc,Boolean isbug)
        {
            Id = id;
            Description = desc;
            isBug = isbug;
        }
        public Feedback(string desc, Boolean isbug,RegisteredUser user)
        {
            Description = desc;
            isBug = isbug;
            registeredUser = user;
        }

        
    }
}