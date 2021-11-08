using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Controller
{
    public interface IController<E, ID> where E : class
    {
        IEnumerable<E> GetAll();
        E Get(ID id);
    }
}
