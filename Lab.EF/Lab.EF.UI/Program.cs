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
            CategoriesLogic categoriesLogic = new CategoriesLogic();

            foreach (var item in categoriesLogic.GetAll())
            {
                Console.WriteLine($"{item.CategoryID} - {item.CategoryName}");

            }

            categoriesLogic.Add(new Categories
            {
                CategoryName = "Repuesto",
                Description = "prueba2"
            });
            /*
            try
            {
                categoriesLogic.Delete(13);
            }
            catch (IdCategorieException e)
            {

                Console.WriteLine(e.Message);
            }*/
            

            foreach (var item in categoriesLogic.GetAll())
            {
                Console.WriteLine($"{item.CategoryID} - {item.CategoryName}");

            }
            Console.ReadLine();
        }
    }
}
