/***********************************************************************
 * Module:  RoomController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Hospital.Controller;
using Hospital.Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class RoomController : IController<Room, long>
    {
        private readonly RoomService _service;

        public RoomController(RoomService service)
        {
            _service = service;
        }

        public Room AddRoom(Room room) => _service.AddRoom(room);

        public Room ChangeRoomType(Room room) => _service.ChangeRoomType(room);

        public void RoomPartition(Room room) => _service.RoomPartition(room);

        public IEnumerable<Room> GetAll() => _service.GetAll();

        public Boolean isRoomFree(IEnumerable<Appointment> appointments, DateTime beginDate, DateTime endDate) => _service.isRoomFree(appointments, beginDate, endDate);

        public Room Get(long id) => _service.Get(id);
    }
}