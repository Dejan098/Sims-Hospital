/***********************************************************************
 * Module:  StaticEquipmentController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.StaticEquipmentController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class StaticEquipmentRepository : CSVRepository<StaticEquipment, long>, IStaticEquipementRepository
    {
        private const string ENTITY_NAME = "StaticEquipment";

        private readonly CSVRepository<Room, long> _roomRepository;

        public StaticEquipmentRepository(ICSVStream<StaticEquipment> stream, ISequencer<long> sequencer, CSVRepository<Room, long> roomRepository) : base(ENTITY_NAME, stream, sequencer) {

            _roomRepository = roomRepository;
        
        }

        public StaticEquipment GetStaticEquipement()
        {
            // TODO: implement
            return null;
        }

        public StaticEquipment FindById(int id)
        {
            // TODO: implement
            return null;
        }

        public StaticEquipment FindByName(String name)
        {
            // TODO: implement
            return null;
        }


        private void BindRoomsWithStaticEquipment(IEnumerable<Room> rooms, IEnumerable<StaticEquipment> staticEquipment)
        {
            staticEquipment.ToList().ForEach(staticEq => staticEq.room = FindRoomById(rooms, staticEq.room.Id));
            
        }
        private Room FindRoomById(IEnumerable<Room> rooms, long id)
            => rooms.SingleOrDefault(room => room.Id == id);

        public IEnumerable<StaticEquipment> GetAllStaticEquipment()
        {
            IEnumerable<Room> rooms = _roomRepository.GetAll();
            IEnumerable<StaticEquipment> staticEquipment = GetAll();
            BindRoomsWithStaticEquipment(rooms, staticEquipment);
            return staticEquipment;
        }

    }
}