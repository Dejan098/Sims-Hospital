/***********************************************************************
 * Module:  DirectorService.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Service.DirectorService
 ***********************************************************************/

using Hospital.Controller;
using Hospital.Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class StaffController : IController<Staff, long>
    {
        private readonly StaffService _service;

        public StaffController(StaffService service)
        {
            _service = service;
        }

        public Staff getByUsernameAndPassword(string username, string password) => _service.getByUsernameAndPassword(username, password);

        public Staff RegisterStaff(Staff staff) => _service.RegisterStaff(staff);

        public void changeWorkingHours(Staff staff, WorkingHours workingHours)
            => _service.ChangeWorkingHours(staff, workingHours);

        public IEnumerable<Staff> GetAll() => _service.GetAll();

        public Staff Get(long id) => _service.Get(id);

        public void Update(Staff staff) => _service.Update(staff);
    }
}