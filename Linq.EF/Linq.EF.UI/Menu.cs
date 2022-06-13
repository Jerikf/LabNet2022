using Linq.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.EF.Logic
{
    public class Menu
    {
        //Modificar con las opciones de cada ejercicio
        public void mostrarMenu()
        {
            Console.WriteLine("-------------MENU--------------|");
            Console.WriteLine("1. EJERCICIO 1                 |");
            Console.WriteLine("2. EJERCICIO 2                 |");
            Console.WriteLine("3. EJERCICIO 3                 |");
            Console.WriteLine("4. EJERCICIO 4                 |");
            Console.WriteLine("5. EJERCICIO 5                 |");
            Console.WriteLine("6. EJERCICIO 6                 |");
            Console.WriteLine("7. EJERCICIO 7                 |");
            Console.WriteLine("8. SALIR                       |");
            Console.WriteLine("-------------------------------|");
        }

        //Modificar con las opciones de cada ejercicio
        public int obtenerOpcion()
        {
            mostrarMenu();
            Console.WriteLine("INGRESE UNA OPCIÓN : ");
            string opcionUsuario = Console.ReadLine();
            int valor = -1;
            while (!Int32.TryParse(opcionUsuario, out valor) || !(valor > 0 && valor <= 8))
            {
                Console.WriteLine("UPS! INGRESÓ UNA OPCIÓN INCORRECTA !");
                mostrarMenu();
                opcionUsuario = Console.ReadLine();
            }
            return valor;
        }

        public void MostrarCliente()
        {
            Console.WriteLine("-------------------------EJERCICIO NRO 1--------------------");
            CustomerLogic customerLogic = new CustomerLogic();
            Customers customer = customerLogic.GetCustomerByID("HILAA");
            Console.WriteLine($"{customer.CustomerID} - {customer.CompanyName} - {customer.ContactName} - {customer.ContactTitle} - {customer.Address} - {customer.City}");
            Console.WriteLine("------------------------------------------------------------");
        }

        public void MostrarProductosSinStock()
        {
            Console.WriteLine("-------------------------EJERCICIO NRO 2--------------------");
            ProductsLogic productsLogic = new ProductsLogic();
            foreach(var product in productsLogic.GetProductsOutStock())
            {
                Console.WriteLine($"{product.ProductName} - {product.UnitPrice} - {product.UnitsInStock} - {product.UnitsOnOrder} - {product.ReorderLevel}");
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        public void MostrarProductConStockYCuestaMasDe3PorUnidad()
        {
            Console.WriteLine("-------------------------EJERCICIO NRO 3--------------------");
            ProductsLogic productsLogic = new ProductsLogic();
            foreach (var product in productsLogic.GetProductsWithStockAndCostMore3ByUnit())
            {
                Console.WriteLine($"{product.ProductName} - {product.UnitPrice} - {product.UnitsInStock} - {product.UnitsOnOrder} - {product.ReorderLevel}");
            }
            Console.WriteLine("------------------------------------------------------------");

        }

        public void MostrarClientesDeRegionWA()
        {
            Console.WriteLine("-------------------------EJERCICIO NRO 4--------------------");
            CustomerLogic customerLogic = new CustomerLogic();
            foreach (var customer in customerLogic.GetCustomersByRegionWA())
            {
                Console.WriteLine($"{customer.CustomerID} - {customer.CompanyName} - {customer.ContactName} - {customer.ContactTitle} - {customer.Address} - {customer.City}");
            }       
            Console.WriteLine("------------------------------------------------------------");
        }

        public void MostrarPrimerElementoDeProductosMayorId789()
        {
            Console.WriteLine("-------------------------EJERCICIO NRO 5--------------------");
            ProductsLogic productsLogic = new ProductsLogic();
            var product = productsLogic.GetProductFirtById789();
            if (product != null)
                Console.WriteLine($"{product.ProductName} - {product.UnitPrice} - {product.UnitsInStock} - {product.UnitsOnOrder} - {product.ReorderLevel}");
            else
                Console.WriteLine("NO HAY NINGÚN PRODUCTO MAYOR AL ID 789");
            Console.WriteLine("------------------------------------------------------------");
        }

        public void MostrarNombreDeClienteEnMayusYMinus()
        {
            Console.WriteLine("-------------------------EJERCICIO NRO 6--------------------");
            CustomerLogic customerLogic = new CustomerLogic();
            foreach (var name in customerLogic.GetCustomerName())
            {
                Console.WriteLine($"{name}");
            }
            Console.WriteLine("------------------------------------------------------------");

        }

        public void MostrarClienteYOrder()
        {
            Console.WriteLine("-------------------------EJERCICIO NRO 7--------------------");
            CustomerLogic customerLogic = new CustomerLogic();
            foreach (var customerOrder in customerLogic.GetJoinCustomerAndOrders())
            {
                Console.WriteLine($"{customerOrder.Customer.CompanyName} - {customerOrder.Customer.Region} ---- {customerOrder.Order.CustomerID} - {customerOrder.Order.OrderDate}");
            }
            Console.WriteLine("------------------------------------------------------------");

        }

       




    }

}
