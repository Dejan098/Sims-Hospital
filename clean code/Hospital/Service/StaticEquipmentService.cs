/***********************************************************************
 * Module:  StaticEquipmentController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.StaticEquipmentController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class StaticEquipmentService:IService<StaticEquipment, long>
    {
        private readonly StaticEquipmentRepository _repository;

        public StaticEquipmentService(StaticEquipmentRepository repository)
        {
            _repository = repository;
        }
        public StaticEquipment Get(long id) => _repository.Get(id);

        public IEnumerable<StaticEquipment> GetAll() => _repository.GetAllStaticEquipment();

        public void DeleteStaticEquipment(StaticEquipment staticEquipment)
        {
            // TODO: implement
        }

        public void OrderStaticEquipment(StaticEquipment staticEquipment, Room room)
        {
            staticEquipment.room = room;
            _repository.Create(staticEquipment);
        }

        public void MoveStaticEquipmentFromWarehouseToRoom(int roomId, int staticEquipmentId)
        {
            // TODO: implement
        }

        public void MoveStaticEquipmentFromRoomToRoom(StaticEquipment staticEquipment, Room room1)
        {
            
            staticEquipment.room = room1;
            _repository.Update(staticEquipment);
        }


    }
}