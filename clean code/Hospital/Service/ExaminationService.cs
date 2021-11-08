using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Service
{
    public class ExaminationService : IService<Examination, long>
    {
        private ExaminationRepository examinationRepository;

        public void Create(Examination examination) => examinationRepository.Create(examination);
        public ExaminationService(ExaminationRepository examinationRepository)
        {
            this.examinationRepository = examinationRepository;
        }

        public IEnumerable<Examination> GetByPatientId(long id) => examinationRepository.GetByPatientId(id);

        public Examination Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Examination> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
