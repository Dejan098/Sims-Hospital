/***********************************************************************
 * Module:  SuppliesController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.SuppliesController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;

namespace Repository
{
    public class SuppliesRepository : CSVRepository<Supplies, long>, ISuppliesRepository
    {
        private const string ENTITY_NAME = "Supplies";

        public SuppliesRepository(ICSVStream<Supplies> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer) { }


        public Supplies GetSupplies()
        {
            // TODO: implement
            return null;
        }

        public Supplies FindById()
        {
            // TODO: implement
            return null;
        }

        public Supplies FindByName()
        {
            // TODO: implement
            return null;
        }

    }
}