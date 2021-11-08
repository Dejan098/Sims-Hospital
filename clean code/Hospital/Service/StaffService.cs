/***********************************************************************
 * Module:  DirectorService.cs
 * Author:  babic
 * Purpose: Definition of the Class Service.DirectorService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Service
{
    public class StaffService:IService<Staff, long>
    {
        private readonly StaffRepository _repository;

        public StaffService(StaffRepository repository)
        {
            _repository = repository;
        }

        public Staff Get(long id) => _repository.Get(id);

        public IEnumerable<Staff> GetAll() => _repository.GetAll();

        public Staff getByUsernameAndPassword(string username, string password)
        {
            Staff staff = _repository.GetByUsernameAndPassword(username, password);
            if (staff == null)
            {
                MessageBox.Show("Pogresno korisnicko ime ili lozinka.");
            }
            return staff;
        }

        public Staff RegisterStaff(Staff staff)
        {
            // TODO: implement
            return null;
        }

        public void ChangeWorkingHours(Staff staff, WorkingHours workingHours)
        {
            // TODO: implement
        }

        public void Update(Staff staff) => _repository.Update(staff);

    }
}