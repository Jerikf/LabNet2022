﻿using Lab.EF.Common;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    //AHORA EL MENÚ LO PONDREMOS EN LA LOGIC, con sus métodos y no implementar en el program método.
    public class Menu
    {
        public void mostrarMenu()
        {
            Console.WriteLine("-------------MENU--------------|");
            Console.WriteLine("1. MOSTRAR LOS SHIPPERS        |");
            Console.WriteLine("2. MOSTRAR CATEGORIES          |");
            Console.WriteLine("3. CREAR CATEGORÍA             |");
            Console.WriteLine("4. ACTUALIZAR CATEGORÍA        |");
            Console.WriteLine("5. ELIMINAR CATEGORÍA          |");
            Console.WriteLine("6. SALIR                       |");
            Console.WriteLine("-------------------------------|");
        }

        public int obtenerOpcion()
        {
            mostrarMenu();
            string opcionUsuario = Console.ReadLine();
            int valor = -1;
            while (!Int32.TryParse(opcionUsuario, out valor) || !(valor > 0 && valor <= 6))
            {
                Console.WriteLine("UPS! INGRESÓ UNA OPCIÓN INCORRECTA !");
                mostrarMenu();
                opcionUsuario = Console.ReadLine();
            }
            return valor;
        }

        public void MostrarShippers()
        {
            Console.WriteLine("-------------SHIPPERS-----------------");
            ShippersLogic shippersLogic = new ShippersLogic();
            foreach (var shipper in shippersLogic.GetAll())
            {
                Console.WriteLine($"{shipper.ShipperID} - {shipper.CompanyName} - {shipper.Phone}");
            }
            Console.WriteLine("--------------------------------------");
        }

        public void MostrarCategories()
        {
            Console.WriteLine("-------------CATEGORIES----------------");
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            foreach (var categorie in categoriesLogic.GetAll())
            {
                Console.WriteLine($"{categorie.CategoryID} - {categorie.CategoryName} - {categorie.Description}");
            }
            Console.WriteLine("--------------------------------------");
        }

        public void CrearCategorie()
        {
            Console.WriteLine("---------------CREAR CATEGORIE--------------");
            string name = ObtenerNombreCategorie();
            string description = ObtenerDescriptionCategorie();

            CategoriesLogic categoriesLogic = new CategoriesLogic();
            categoriesLogic.Add(new Categories()
            {
                CategoryName = name,
                Description = description
            });
            Console.WriteLine("--------------------------------------");
        }
        

        public void ActualizarCategorie()
        {
            Console.WriteLine("------------------ACTUALIZAR CATEGORIE----------------");
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            
            int id = ObtenerIdCategorie();
            string name = ObtenerNombreCategorie();
            string description = ObtenerDescriptionCategorie();
            Categories categorie = new Categories()
            {
                CategoryID = id,
                CategoryName = name,
                Description = description
            };
            try
            {
                categoriesLogic.Update(categorie);
            }
            catch(IdCategorieException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteCategorie()
        {
            Console.WriteLine("------------------DELETE CATEGORIE----------------");
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            int id = ObtenerIdCategorie();
            try
            {
                categoriesLogic.Delete(id);
            }
            catch(IdCategorieException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR --> POSIBLEMENTE POR QUERER ELIMINAR UN ID QUE TIENE RELACIÓN CON OTRAS ENTITDADES");
            }
        }


        private int ObtenerIdCategorie()
        {
            Console.WriteLine("INGRESE EL ID");
            string opcion = Console.ReadLine();
            int id = -1;
            while (!Int32.TryParse(opcion, out id))
            {
                Console.WriteLine("UPS! --> INGRESE NUEVAMENTE EL ID");
                opcion = Console.ReadLine();
            }
            return id;

        }


        private string ObtenerDescriptionCategorie()
        {
            Console.WriteLine("INGRESE UNA DESCRIPCIÓN : ");
            string description = Console.ReadLine();
            return description;

        }

        private string ObtenerNombreCategorie()
        {
            Console.WriteLine("INGRESE NOMBRE - MÁXIMO 15 CARACTERES:");
            string name = Console.ReadLine();
            while (name.Length == 0 || name.Length > 15)
            {
                Console.WriteLine("UPS! --> INGRESE NUEAVMENTE UN NOMBRE - MÁXIMO 15 CARACTERES POR FAVOR:");
                name = Console.ReadLine();
            }
            return name;
        }

    }
}
