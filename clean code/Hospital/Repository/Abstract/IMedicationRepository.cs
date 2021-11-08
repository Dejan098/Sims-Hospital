using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.Abstract
{
    public interface IMedicationRepository : IRepository<Medication, long>
    {
    }
}
