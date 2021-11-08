/***********************************************************************
 * Module:  RoomController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class RoomService:IService<Room, long>
    {
        private readonly RoomRepository _repository;

        public RoomService(RoomRepository repository)
        {
            _repository = repository;
        }



        public Room Get(long id) => _repository.Get(id);


        public IEnumerable<Room> GetAll()
        {
            return _repository.GetAll();
        }

        public Boolean isRoomFree(IEnumerable<Appointment> appointments, DateTime beginDate, DateTime endDate) {
            foreach (Appointment appointment in appointments) {

                if (((beginDate <= appointment.Room.BeginningOfRoomOccupancy && endDate <= appointment.Room.BeginningOfRoomOccupancy) || (beginDate >= appointment.Room.EndOfRoomOccupancy && endDate >= appointment.Room.EndOfRoomOccupancy))==false)
                {
                    return false;
                }

            }
            return true;
        }
        public Boolean IsRoomFree(Room room, DateTime dateTimeBegin, DateTime dateTimeEnd)
        {
            // TODO: implement
            return true;
        }

        public Room AddRoom(Room room)
        {
            // TODO: implement
            return null;
        }


        public Room ChangeRoomType(Room room)
        {
            // TODO: implement
            return null;
        }

        public void RoomPartition(Room room)
        {
            // TODO: implement
        }

        public List<Room> GetListOfFreeOperationRooms(DateTime date)
        {
            // TODO: implement
            return null;
        }

        
    }
}