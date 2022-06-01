using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2UniTest
{
    public class MiExepcion : Exception
    {
        public MiExepcion(String mensaje) : base(mensaje) { }
    }
}
