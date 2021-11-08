using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository
{
    public class ExaminationRepository : CSVRepository<Examination, long>, IExaminationRepository
    {
        private CSVStream<Examination> cSVStream;
        private LongSequencer longSequencer;
        private const string ENTITY_NAME = "Examination";

        public ExaminationRepository(ICSVStream<Examination> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer) { }

        public IEnumerable<Examination> GetByPatientId(long id)
            => Find(examination  => examination.IdPatient == id);
    }
}
