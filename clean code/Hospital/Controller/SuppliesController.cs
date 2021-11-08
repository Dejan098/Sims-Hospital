/***********************************************************************
 * Module:  SuppliesController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.SuppliesController
 ***********************************************************************/

using Hospital.Controller;
using Hospital.Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class SuppliesController : IController<Supplies, long>
    {
        private  SuppliesService _service;

        public SuppliesController(SuppliesService service)
        {
            _service = service;
        }

        public void DecreaseQuantityOfSupplies(Supplies supply, int quantity)
            => _service.DecreaseQuantityOfSupplies(supply, quantity);

        public void OrderSupplies(Supplies supply, int quantity)
            => _service.OrderSupplies(supply, quantity);

        public IEnumerable<Supplies> GetAll() => _service.GetAll();


        public Supplies Get(long id) => _service.Get(id);


    }
}
