/***********************************************************************
 * Module:  StaticEquipmentController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.StaticEquipmentController
 ***********************************************************************/

using Hospital.Controller;
using Hospital.Model;
using Service;
using System;
using System.Collections.Generic;


namespace Controller
{
    public class StaticEquipmentController : IController<StaticEquipment, long>
    {
        private readonly StaticEquipmentService _service;

        public StaticEquipmentController(StaticEquipmentService service)
        {
            _service = service;
        }

        public void DeleteStaticEquipment(StaticEquipment staticEquipment) => _service.DeleteStaticEquipment(staticEquipment);

        public void OrderStaticEquipment(StaticEquipment staticEquipment, Room room) => _service.OrderStaticEquipment(staticEquipment,room);

        public void MoveStaticEquipmentFromWarehouseToRoom(int roomId, int staticEquipmentId)
            => _service.MoveStaticEquipmentFromWarehouseToRoom(roomId, staticEquipmentId);

        public void MoveStaticEquipmentFromRoomToRoom(StaticEquipment staticEquipment, Room room)

            => _service.MoveStaticEquipmentFromRoomToRoom(staticEquipment,room);

        public IEnumerable<StaticEquipment> GetAll() => _service.GetAll();

        public StaticEquipment Get(long id) => _service.Get(id);

        


    }
}