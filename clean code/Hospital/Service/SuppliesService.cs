/***********************************************************************
 * Module:  SuppliesController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.SuppliesController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class SuppliesService:IService<Supplies, long>
    {
        private readonly SuppliesRepository _repository;

        public SuppliesService(SuppliesRepository repository)
        {
            _repository = repository;
        }
        public Supplies Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplies> GetAll()
        {
            var supplies = _repository.GetAll();
            return supplies;
        }

        public void DecreaseQuantityOfSupplies(Supplies supply, int quantity)
        {
            // TODO: implement
        }

        public void OrderSupplies(Supplies supply, int quantity)
        {
            // TODO: implement
        }

       


    }
}
