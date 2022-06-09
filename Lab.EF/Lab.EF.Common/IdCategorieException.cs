using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Common
{
    public class IdCategorieException : Exception
    {
        public IdCategorieException() : base("El id no existe") { }
    }
}
