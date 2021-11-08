/***********************************************************************
 * Module:  PatientsFileController.cs
 * Author:  babic
 * Purpose: Definition of the Class Controller.PatientsFileController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;

namespace Repository
{
    public class FileRepository : CSVRepository<File, long>, IFileRepositoty
    {
        private const string ENTITY_NAME = "File";

        public FileRepository(ICSVStream<File> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer) { }

        public File GetPatientsFile(File patientsFile)
        {
            // TODO: implement
            return null;
        }
    }
}