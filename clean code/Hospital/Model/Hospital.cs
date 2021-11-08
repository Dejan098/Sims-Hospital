/***********************************************************************
 * Module:  Bolnica.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Hospital
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Hospital
    {
        public Appointment[] appointment;
        public Notification[] notification;
        public Hospital hospitalA;

        public String Name;
        public String Address;
        public static Hospital Instance;

        public static Hospital GetInstance()
        {
            if (Instance == null)
                Instance = new Hospital();
            return Instance;
        }

        private Hospital()
        {
            // TODO: implement
        }

        public System.Collections.ArrayList faq;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetFaq()
        {
            if (faq == null)
                faq = new System.Collections.ArrayList();
            return faq;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetFaq(System.Collections.ArrayList newFaq)
        {
            RemoveAllFaq();
            foreach (Faq oFaq in newFaq)
                AddFaq(oFaq);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddFaq(Faq newFaq)
        {
            if (newFaq == null)
                return;
            if (this.faq == null)
                this.faq = new System.Collections.ArrayList();
            if (!this.faq.Contains(newFaq))
                this.faq.Add(newFaq);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveFaq(Faq oldFaq)
        {
            if (oldFaq == null)
                return;
            if (this.faq != null)
                if (this.faq.Contains(oldFaq))
                    this.faq.Remove(oldFaq);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllFaq()
        {
            if (faq != null)
                faq.Clear();
        }
        public Warehouse warehouse;
        public City city;
        public Staff[] staff;
        public System.Collections.ArrayList room;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetRoom()
        {
            if (room == null)
                room = new System.Collections.ArrayList();
            return room;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetRoom(System.Collections.ArrayList newRoom)
        {
            RemoveAllRoom();
            foreach (Room oRoom in newRoom)
                AddRoom(oRoom);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddRoom(Room newRoom)
        {
            if (newRoom == null)
                return;
            if (this.room == null)
                this.room = new System.Collections.ArrayList();
            if (!this.room.Contains(newRoom))
                this.room.Add(newRoom);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveRoom(Room oldRoom)
        {
            if (oldRoom == null)
                return;
            if (this.room != null)
                if (this.room.Contains(oldRoom))
                    this.room.Remove(oldRoom);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllRoom()
        {
            if (room != null)
                room.Clear();
        }

    }
}