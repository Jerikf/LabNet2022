using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1.Logica
{
    public class ManejadorDeTransporte
    {
        List<TransportePublico> transportes = new List<TransportePublico>();
        int cantTaxis;
        int cantOmnibus;

        ManejadorDeTransporte(List<TransportePublico> transportes, int cantTaxis, int cantOmnibus)
        {
            this.transportes = transportes;
            this.cantTaxis = cantTaxis;
            this.cantOmnibus = cantOmnibus;
        }
        ManejadorDeTransporte()
        {
            this.cantTaxis = 0;
            this.cantOmnibus = 0;
        }

        //PRE: Recibe un taxi
        //POS: Agregar un taxi a la lista de Transporte si y solo si aún no se completó los 5 taxis, si se agregó devuelve true sino pudo agregarlo false
        public bool agregarTransporte(TransportePublico transporte)
        {
            bool estado = true;
            if(transporte is Taxi && cantTaxis < 5)
            {
                transportes.Add(transporte);
                cantTaxis++;

            }else if(transporte is Omnibus && cantOmnibus < 5)
            {
                transportes.Add(transporte);
                cantOmnibus++;

            }
            else
            {
                estado = false;
            }

            
            return estado;
        }

    }
}
