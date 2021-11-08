/***********************************************************************
 * Module:  RoomController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;

namespace Repository
{
    public class RoomRepository : CSVRepository<Room, long>, IRoomRepository
    {
        private const string ENTITY_NAME = "Room";

        public RoomRepository(ICSVStream<Room> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer) { }

       

        public int FindFreeOperatonRoomsByDate(DateTime date)
        {
            // TODO: implement
            return 0;
        }

    }
}