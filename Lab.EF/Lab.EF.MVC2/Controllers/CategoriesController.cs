using Lab.EF.Common;
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
                CategoryID = categorie.CategoryID,
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
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                categoriesLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (IdCategorieException e)
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("IdRelation", "Error");
            }
            
        }

        public ActionResult Update(int id)
        {
            try
            {
                Categories categorie = categoriesLogic.GetAll().Find(c => c.CategoryID == id);
                CategoriesView categorieView = new CategoriesView()
                {
                    CategoryID = categorie.CategoryID,
                    CategoryName = categorie.CategoryName,
                    Description = categorie.Description
                };
                return View(categorieView);
            }
            catch (ArgumentNullException)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Update(CategoriesView categorie)
        {
            try
            {
                Categories newCategorie = new Categories()
                {
                    CategoryID = categorie.CategoryID,
                    CategoryName = categorie.CategoryName,
                    Description = categorie.Description
                };
                categoriesLogic.Update(newCategorie);
                return RedirectToAction("Index");
            }
            catch (IdCategorieException)
            {
                return RedirectToAction("Index", "Error");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}