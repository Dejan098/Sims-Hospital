/***********************************************************************
 * Module:  PatientsFileController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.PatientsFileController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class FileService:IService<File, long>
    {
        private readonly FileRepository _repository;

        public FileService(FileRepository repository)
        {
            _repository = repository;
        }

        public File Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> GetAll()
        {
            throw new NotImplementedException();
        }


        public void WriteAnamnesis(Patient patient, String Text)
        {
            // TODO: implement
        }

    }
}