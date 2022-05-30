using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1.Logica
{
    public class ManejadorDeTransporte
    {
        List<TransportePublico> transportes;
        int cantTaxis;
        int cantOmnibus;
        int cantTransporteConPasajeros;

        public ManejadorDeTransporte(List<TransportePublico> transportes, int cantTaxis, int cantOmnibus)
        {
            this.transportes = transportes;
            this.cantTaxis = cantTaxis;
            this.cantOmnibus = cantOmnibus;
        }
        public ManejadorDeTransporte()
        {
            this.cantTaxis = 0;
            this.cantOmnibus = 0;
            this.transportes = new List<TransportePublico>();
            this.cantTransporteConPasajeros = 0;
        }

        public List<TransportePublico> Transportes { get => transportes; set => transportes = value; }
        public int CantTaxis { get => cantTaxis; set => cantTaxis = value; }
        public int CantOmnibus { get => cantOmnibus; set => cantOmnibus = value; }


        //PRE: Recibe un taxi
        //POS: Agregar un taxi a la lista de Transporte si y solo si aún no se completó los 5 taxis, si se agregó devuelve true sino pudo agregarlo false
        public bool AgregarTransporte(TransportePublico transporte)
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
                estado = false;


            
            return estado;
        }

        //PRE: Recibe un indice que le corresponde al transporte elegido y la cantidad de pasajeros para agregar
        //POS: Devuelve true si el indice del transporte es el correcto y este no contienne ningún pasajero ya cargado, caso contrario retorna false
        public bool AgregarPasajero(int indiceTransporte, int cantPasajeros)
        {
            bool resultado = false;
            if (indiceTransporte > transportes.Count)
                Console.WriteLine("UPS! ESCOGIÓ UN TRANSPORTE INEXISTENTE");
            else if (transportes[indiceTransporte].CantPasajeros > 0)
                Console.WriteLine("ESCOGIÓ UN TRANSPORTE QUE YA TIENE PASAJEROS AGREGADOS");
            else if (transportes[indiceTransporte] is Taxi && cantPasajeros > 4)
                Console.WriteLine("UPS! LOS TAXI NO PUEDEN TENER MAS DE 4 PASAJEROS");
            else
            {
                transportes[indiceTransporte].CantPasajeros = cantPasajeros;
                cantTransporteConPasajeros++;
                resultado = true;
                Console.WriteLine("SE PUDO AGREGAR CORRECTAMENTE LA CANTIDAD DE PASAJEROS BRINDADOS ");
            }
            return resultado;
            

        }

        //PRE:
        //POS: Muestra todos los transportes que tengan aún pasajeros cargados
        public bool MostrarTransportesSinPasajeros()
        {
            bool estado = false;
            //int cantidad = 1;
            if (transportes.Count == 0)
                Console.WriteLine("AÚN NO CONTAMOS CON TRANSPORTES");
            else if (cantTransporteConPasajeros == transportes.Count)
                Console.WriteLine("LOS TRANSPORTES DISPONIBLES YA CUENTAN CON PASAJEROS");
            else
            {
                estado = true;
                Console.WriteLine("SELECCIONAR EL NÚMERO DE TRANSPORTE PARA PODER AGREGAR PASAJEROS");
                Console.WriteLine("-------------------------------------------------------------------");
                for (int i = 0; i < transportes.Count; i++)
                {
                    if (transportes[i].CantPasajeros == 0)
                        Console.WriteLine($"{i + 1}. SOY UN {((transportes[i] is Taxi) ? "TAXI" : "OMNIBUS")} NÚMERO {i + 1}");
                }
                Console.WriteLine("-------------------------------------------------------------------\n\n\n");

            }
            return estado;
        }

        //PRE:
        //POS: Muestra todos los transportes con los pasajeros que cada uno tiene
        public void MostrarTransportesConCantPasajeros()
        {
            int cant = 1;
            foreach (var transporte in transportes)
            {
                Console.WriteLine($"{cant} SOY UN {((transporte is Taxi) ? "TAXI" : "OMNIBUS")} Y TENGO {transporte.CantPasajeros} PASAJEROS");
                cant++;
            }
        }


        //PRE: Recibe un indice donde se puede ubicar el transporte
        //POS: Retorna true si el transporte en esa posición es válida y además no contiene pasajeros cargados, caso contrario retorna false
        public bool VerificarTransporteVacio(int indice)
        {
            if (indice >= transportes.Count) Console.WriteLine("EL TRANSPORTE QUE ESCOGIÓ ES INVÁLIDO");
            else if (transportes[indice].CantPasajeros > 0) Console.WriteLine("EL TRANSPORTE YA CUNETA CON PASAJEROS AGREGADOS");

            return (indice < transportes.Count && transportes[indice].CantPasajeros == 0);

        }
    }
}
