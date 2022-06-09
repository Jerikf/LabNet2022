using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    interface IABMLogic<T>
    {
        List<T> GetAll();
        void Add(T item);
        void Delete(int id);
        void Update(T item);

    }
}
