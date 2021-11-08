/***********************************************************************
 * Module:  Notification.cs
 * Author:  Dragan
 * Purpose: Definition of the Class Notification
 ***********************************************************************/

using Hospital.Model.Abstract;
using System;

namespace Hospital.Model
{
    public class Notification : IIdentifiable<long>
    {
        public String Text { get; set; }
        public long Id { get; set; }
        
        //Preimenovati u idReceiver ili nesto
        public long IdDoctor { get; set; }

        public Notification(long id, string text, long idDoctor)
        {
            Id = id;
            Text = text;
            IdDoctor = idDoctor;
        }

        public Notification(string text, long idDoctor)
        {
            Text = text;
            IdDoctor = idDoctor;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}