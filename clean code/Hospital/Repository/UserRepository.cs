/***********************************************************************
 * Module:  UserService.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;

namespace Repository
{
    public class UserRepository : CSVRepository<RegisteredUser, long>, IUserRepository
    {
        private const string ENTITY_NAME = "User";

        public UserRepository(ICSVStream<RegisteredUser> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer) { }

        public RegisteredUser GetUser()
        {
            // TODO: implement
            return null;
        }

        public void SetUser(RegisteredUser user)
        {
            // TODO: implement
        }

        public RegisteredUser SaveUser(RegisteredUser user)
        {
            // TODO: implement
            return null;
        }

        public RegisteredUser FindById(int id)
        {
            // TODO: implement
            return null;
        }

        public RegisteredUser FindByUsername(String username)
        {
            // TODO: implement
            return null;
        }

        public RegisteredUser FindByName(String name)
        {
            // TODO: implement
            return null;
        }

        public RegisteredUser FindBySurname(String surname)
        {
            // TODO: implement
            return null;
        }


    }
}