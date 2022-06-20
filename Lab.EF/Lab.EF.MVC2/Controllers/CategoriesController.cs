using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC2.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesLogic categoriesLogic = new CategoriesLogic();
        // GET: Categories
        public ActionResult Index()
        {
            List<Categories> categories = categoriesLogic.GetAll();
            List<CategoriesView> categoriesViews = categories.Select(categorie => new CategoriesView
            {
                CategoriesId = categorie.CategoryID,
                CategoryName = categorie.CategoryName,
                Description = categorie.Description,
            }).ToList();
            return View(categoriesViews);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoriesView categorieView)
        {
            try
            {
                Categories categorieNew = new Categories
                {
                    CategoryName = categorieView.CategoryName,
                    Description = categorieView.Description,
                };

                categoriesLogic.Add(categorieNew);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

    }
}