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

        [HttpPost]
        public ActionResult Insert()
        {
            return View();
        }
    }
}