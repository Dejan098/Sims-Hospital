/***********************************************************************
 * Module:  UserService.cs
 * Author:  Dragan
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class UserService:IService<RegisteredUser, long>
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public RegisteredUser Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            throw new NotImplementedException();
        }
        public void logIn(String username, String password)
        {
            // TODO: implement
        }

        public void LogOut()
        {
            // TODO: implement
        }

        public void ViewProfile(RegisteredUser user)
        {
            // TODO: implement
        }

        public void ReportBug(String text)
        {
            // TODO: implement
        }

        
    }
}