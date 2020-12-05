using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMobileRefact
{
    class CRUDFactory
    {
        public T MakeCRUD<T>() where T : class, new()
        {
            return new T();
        }
    }
}
