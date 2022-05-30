using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tp1.Logica;
using tp1.Vista;

namespace tp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            ManejadorDeTransporte manejadorDeTransporte = new ManejadorDeTransporte();
            int opcion = 0;
            menu.mostrarMenuPrincipal();
            opcion = obtenerOpcion(4);

            while (opcion != Constants.Salir)
            {
                
                if (opcion == Constants.IngresarTransporte)
                {
                    menu.mostrarMenuTransportePublico();
                    opcion = obtenerOpcion(3);
                    while(opcion != 3)
                    {
                        if (opcion == Constants.AgregarTaxi)
                            if (manejadorDeTransporte.AgregarTransporte(new Taxi()))
                            {
                                Console.WriteLine("SE AGREGÓ CORRECTAMENTE EL TAXI");
                                Limpiar(1100);
                            }
                            else
                            {
                                Console.WriteLine("UPS! NO SE PUDO AGREGAR , PORQUE YA CUENTA CON 5 TAXIS AGREGADOS");
                                Limpiar(1100);
                            }
                                
                        else
                        {
                            if (manejadorDeTransporte.AgregarTransporte(new Omnibus()))
                            {
                                Console.WriteLine("SE AGREGÓ CORRECTAMENTE EL OMBNIBUS");
                                Limpiar(1100);
                            }
                            else
                            {
                                Console.WriteLine("UPS! NO SE PUDO AGREGAR , PORQUE YA CUENTA CON 5 OMNIBUS AGREGADOS");
                                Limpiar(1200);
                            }
                                
                        }
                        menu.mostrarMenuTransportePublico();
                        opcion = obtenerOpcion(3);
                    }
                    Console.Clear();
                }
                else if(opcion == Constants.IngresarPasajero)
                {
                    
                    int opcionTransporte = 0;
                    bool seAgregoPasajero = false;
                    int cantPasajeros = 0;
                    Console.WriteLine("----------------TRANSPORTES PÚBLICOS----------------");
                    if(manejadorDeTransporte.MostrarTransportesSinPasajeros())
                    {
                        do
                        {
                            opcionTransporte = obtenerOpcionTransporte();
                        } while (!manejadorDeTransporte.VerificarTransporteVacio(opcionTransporte - 1));

                        Limpiar(1200);
                        while (!seAgregoPasajero)
                        {
                            cantPasajeros = ObtenerCantPasajeros();
                            if (manejadorDeTransporte.AgregarPasajero(opcionTransporte - 1, cantPasajeros))
                                seAgregoPasajero = true;
                        }
                        Limpiar(1200);

                    }
                    Limpiar(1000);

                }
                else if(opcion == Constants.MostrarTransporteConSusPasajeros)
                {
                    manejadorDeTransporte.MostrarTransportesConCantPasajeros();
                    Limpiar(2000);
                }
                menu.mostrarMenuPrincipal();
                opcion = obtenerOpcion(4);
            }
            Console.Clear();
            Console.WriteLine("--------------------------------------HASTA LUEGO----------------------------------");
        }



        //PRE: Recibe el rango de opción que se deberá seleccionar como máximo
        //POS: Retorna la opcion correcta del "menus" que el usuario escogio(insiste al usuario hasta que de con las condicoines)
        static int obtenerOpcion(int rangoHasta)
        {
            int valor = 0;
            string opcion = "";
            do
            {
                Console.WriteLine($"INGRESE UNA OPCIÓN (1-{rangoHasta})");
                opcion = Console.ReadLine();
            }while(!Int32.TryParse(opcion, out valor) || !(valor > 0 && valor <= rangoHasta));

            return valor;
        }

        //PRE:
        //POS: Retorna la opcion correcta del "menus de tranportes" que el usuario escogio(insiste al usuario hasta que de con las condicoines)
        static int obtenerOpcionTransporte()
        {
            int valor = 0;
            string opcion = "";
            do
            {
                Console.WriteLine("INGRESE UNA OPCIÓN DE TRANSPORTE: ");
                opcion = Console.ReadLine();
            } while (!Int32.TryParse(opcion, out valor) || !(valor > 0 && valor <= 10));

            return valor;

        }

        //PRE:
        //POS: Retorna la opcion correcta de la cantidad de pasajeros que el usuario escogio(insiste al usuario hasta que de con las condicoines)
        static int ObtenerCantPasajeros()
        {
            int valor = 0;
            string opcion = "";
            do
            {
                Console.WriteLine("INGRESE LA CANTIDAD DE PASAJEROS QUE DESEA AGREGAR PARA EL TRANSPORTE ELEGIDO(TAXI MÁXIMO 4 PASAJEROS Y OMBNIBUS 100) : ");
                opcion = Console.ReadLine();
            } while (!Int32.TryParse(opcion, out valor) || !(valor > 0 && valor <= 100));

            return valor;
        }  

        //PRE: Recibe un entero que será la cantidad de segundos de tiempo de espera.(1 segundo = 1000(valor numerico))
        //POS: Limpia la pantalla según el tiempo de espera brindado
        static void Limpiar(int tiempo)
        {
            Thread.Sleep(tiempo);
            Console.Clear();

        }
    }
}
