/***********************************************************************
 * Module:  PatientsFileController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.PatientsFileController
 ***********************************************************************/

using Hospital.Controller;
using Hospital.Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class FileController : IController<File, long>
    {
        private readonly FileService _service;

        public FileController(FileService service)
        {
            _service = service;
        }

        public File Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> GetAll()
        {
            throw new NotImplementedException();
        }

        public void WriteAnamnesis(Patient patient)
        {
            // TODO: implement
        }
    }
}