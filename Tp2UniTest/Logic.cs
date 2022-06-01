using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2UniTest
{
    public class Logic
    {
        public void ExcepcionArgumentOutOfRange()
        {
            throw new ArgumentOutOfRangeException();
        }
        public void ExcepcionPersonalizada()
        {
            throw new MiExepcion("UPS! A VECES LAS COSAS NO SALEN COMO UNO SE LO ESPERA");

        }
    }
}
