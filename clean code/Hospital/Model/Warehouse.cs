/***********************************************************************
 * Module:  Magacin.cs
 * Author:  Dragan
 * Purpose: Definition of the Class Warehouse
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Warehouse
    {
        public System.Collections.ArrayList staticEquipment;
        public System.Collections.ArrayList supplies;
        public Medication[] medication;


        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetStaticEquipment()
        {
            if (staticEquipment == null)
                staticEquipment = new System.Collections.ArrayList();
            return staticEquipment;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetStaticEquipment(System.Collections.ArrayList newStaticEquipment)
        {
            RemoveAllStaticEquipment();
            foreach (StaticEquipment oStaticEquipment in newStaticEquipment)
                AddStaticEquipment(oStaticEquipment);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddStaticEquipment(StaticEquipment newStaticEquipment)
        {
            if (newStaticEquipment == null)
                return;
            if (this.staticEquipment == null)
                this.staticEquipment = new System.Collections.ArrayList();
            if (!this.staticEquipment.Contains(newStaticEquipment))
                this.staticEquipment.Add(newStaticEquipment);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveStaticEquipment(StaticEquipment oldStaticEquipment)
        {
            if (oldStaticEquipment == null)
                return;
            if (this.staticEquipment != null)
                if (this.staticEquipment.Contains(oldStaticEquipment))
                    this.staticEquipment.Remove(oldStaticEquipment);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllStaticEquipment()
        {
            if (staticEquipment != null)
                staticEquipment.Clear();
        }

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetSupplies()
        {
            if (supplies == null)
                supplies = new System.Collections.ArrayList();
            return supplies;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetSupplies(System.Collections.ArrayList newSupplies)
        {
            RemoveAllSupplies();
            foreach (Supplies oSupplies in newSupplies)
                AddSupplies(oSupplies);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddSupplies(Supplies newSupplies)
        {
            if (newSupplies == null)
                return;
            if (this.supplies == null)
                this.supplies = new System.Collections.ArrayList();
            if (!this.supplies.Contains(newSupplies))
                this.supplies.Add(newSupplies);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveSupplies(Supplies oldSupplies)
        {
            if (oldSupplies == null)
                return;
            if (this.supplies != null)
                if (this.supplies.Contains(oldSupplies))
                    this.supplies.Remove(oldSupplies);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllSupplies()
        {
            if (supplies != null)
                supplies.Clear();
        }
    }
}