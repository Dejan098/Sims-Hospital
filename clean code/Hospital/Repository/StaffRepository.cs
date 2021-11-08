/***********************************************************************
 * Module:  SecretaryService.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Service.SecretaryService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class StaffRepository : CSVRepository<Staff, long>, IStaffRepository
    {
        private const string ENTITY_NAME = "Staff";

        public StaffRepository(ICSVStream<Staff> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer) { }

        public Staff GetStaff()
        {
            // TODO: implement
            return null;
        }

        public Staff GetByUsernameAndPassword(string username, string password)
        {
            return _stream
                .ReadAll()
                .SingleOrDefault(entity => entity.Username == username & entity.Password == password);
        }

        public IEnumerable<Staff> GetAllDoctors() => Find(staff => staff.Role == "doctor");

    }
}
