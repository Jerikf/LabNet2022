using Linq.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            int opcion = menu.obtenerOpcion();
            while (opcion != 14)
            {
                switch (opcion)
                {
                    case 1:
                        menu.MostrarCliente();
                        break;
                    case 2:
                        menu.MostrarProductosSinStock();
                        break;
                    case 3:
                        menu.MostrarProductConStockYCuestaMasDe3PorUnidad();
                        break;
                    case 4:
                        menu.MostrarClientesDeRegionWA();
                        break;
                    case 5:
                        menu.MostrarPrimerElementoDeProductosMayorId789();
                        break;
                    case 6:
                        menu.MostrarNombreDeClienteEnMayusYMinus();
                        break;
                    case 7:
                        menu.MostrarClienteYOrder();
                        break;
                    case 8:
                        menu.MostrarTresPrimerosClientesDeLaRegionWA();
                        break;
                    case 9:
                        menu.MostrarProductosOrdenadorPorNombre();
                        break;
                    case 10:
                        menu.MostrarProductosOrdenadosPorUnitStockDesc();
                        break;
                    case 11:
                        menu.MostrarCategoriasAsociadosAProduct();
                        break;
                    case 12:
                        menu.MostrarPrimerProduct();
                        break;
                    case 13:
                        menu.MostrarClientesConCantOrderAsociadas();
                        break;
                    default:
                        break;
                }
                opcion = menu.obtenerOpcion();
            }

            Console.WriteLine("HASTA LA PRÓXIMA!");
        }
    }
}
