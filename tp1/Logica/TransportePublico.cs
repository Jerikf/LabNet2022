using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1.Logica
{
    public abstract class TransportePublico
    {
        protected int cantPasajeros;

        public TransportePublico(int cantPasajeros)
        {
            this.cantPasajeros = cantPasajeros;
        }
        public TransportePublico() 
        {
            this.cantPasajeros = 0;
        }

        public int CantPasajeros { get => cantPasajeros; set => cantPasajeros = value; }

        public virtual void Avanzar()
        {
            Console.WriteLine("Avanzo");
        }
        public virtual void Detenerse()
        {
            Console.WriteLine("Me detengo");
        }

    }
}
