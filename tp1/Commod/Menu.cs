using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1.Vista
{
    public class Menu
    {
        public void mostrarMenuPrincipal()
        {
            Console.WriteLine("|----------------------BIENVENIDO--------------------------|");
            Console.WriteLine("|1. INGRESAR UN TRANSPORTE                                 |");
            Console.WriteLine("|2. INGRESAR CANTIDAD DE PASAJERO EN EL TRANSPORTE         |");
            Console.WriteLine("|3. MOSTRAR LOS TRANSPORTES CON SU CANTIDAD DE PASAJEROS   |");
            Console.WriteLine("|4. SALIR                                                  |");
            Console.WriteLine("|----------------------------------------------------------|");
        }

        public void mostrarMenuTransportePublico()
        {
            Console.WriteLine("|--------------TRANSPORTE PÚBLICO-----------------|");
            Console.WriteLine("|1. AGREGAR UN TAXI                               |");
            Console.WriteLine("|2. AGREGAR UN OMNIBUS                            |");
            Console.WriteLine("|3. VOLVER AL MENU ANTERIOR                       |");
            Console.WriteLine("|-------------------------------------------------|");

        }

        public void mostrarMenuIngresarPasajero()
        {
            Console.WriteLine("|--------------TRANSPORTE PÚBLICO-----------------|");
            Console.WriteLine("|1. SELECCIONAR UN TAXI                           |");
            Console.WriteLine("|2. SELECCIONAR UN OMNIBUS                        |");
            Console.WriteLine("|3. VOLVER AL MENU ANTERIOR                       |");
            Console.WriteLine("|-------------------------------------------------|");
        }
    }
}
