using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Controller
{
    public class ExaminationController : IController<Examination, long>
    {
        private ExaminationService examinationService;

        public void Create(Examination examination) => examinationService.Create(examination);
        public ExaminationController(ExaminationService examinationService)
        {
            this.examinationService = examinationService;
        }

        public IEnumerable<Examination> GetByPatientId(long id) => examinationService.GetByPatientId(id);

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
