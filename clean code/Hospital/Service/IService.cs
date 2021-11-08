using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Service
{
    public interface IService<E, ID> where E : class
    {
        E Get(ID id);
        IEnumerable<E> GetAll();
  
    }
}
