using Lab.EF.Common;
using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            int opcion = menu.obtenerOpcion();
            while (opcion != 6)
            {
                switch (opcion)
                {
                    case 1:
                        menu.MostrarShippers();
                        break;
                    case 2:
                        menu.MostrarCategories();
                        break;
                    case 3:
                        menu.CrearCategorie();
                        break;
                    case 4:
                        menu.ActualizarCategorie();
                        break;
                    case 5:
                        menu.DeleteCategorie();
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
