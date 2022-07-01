using Lab.EF.Common;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.WebApi.Models;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using EnableCorsAttribute = System.Web.Http.Cors.EnableCorsAttribute;

namespace Lab.EF.WebApi.Controllers
{
    [EnableCors(origins: "https://localhost:44377", headers: "*", methods: "*")]
    public class CategoriesController : ApiController
    {
        CategoriesLogic categoriesLogic = new CategoriesLogic();

        //GET: api/Categories
        public IHttpActionResult GetAll()
        {
            List<Categories> categories = categoriesLogic.GetAll();
            if (categories.Count == 0) return NotFound();
            List<CategorieView> categorieViews = categories.Select(c => new CategorieView
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();

            return Ok(categorieViews);
        }

        //GET: api/Categories/
        public IHttpActionResult Get(int id)
        {
            try
            {
                Categories categorie = categoriesLogic.GetAll().Find(c => c.CategoryID == id);
                //if (categorie == null) return NotFound(); --> ¿Cuál sería más conveniente retornar NotFound directo porque sé que el valor puede ser nulo, o controlarlo como una excepcióno? --> consultarlo
                CategorieView categorieView = new CategorieView()
                {
                    CategoryID = categorie.CategoryID,
                    CategoryName = categorie.CategoryName,
                    Description = categorie.Description
                };
                return Ok(categorieView);

            }catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] CategorieView categorieView)
        {
            if (!ModelState.IsValid || categorieView == null) return BadRequest("Puso mal los datos");
            Categories categorie = new Categories()
            {
                CategoryName = categorieView.CategoryName,
                Description = categorieView.Description
            };
            try
            {
                categoriesLogic.Add(categorie);
                return Ok("SE AGREGÓ LA CATEGORÍA CORRECTAMENTE");
            }catch(Exception)
            {
                return BadRequest("NO ESTÁ RESPETANDO EL FORMATO CORRECTO"); 
            }
            

        }

        public IHttpActionResult Patch([FromBody] CategorieView categorieView)
        {
            if (!ModelState.IsValid || categorieView == null) return BadRequest("Puso mal los datos");
            Categories categorie = new Categories()
            {
                CategoryID = categorieView.CategoryID,
                CategoryName = categorieView.CategoryName,
                Description = categorieView.Description
            };
            try
            {
                categoriesLogic.Update(categorie);
                return Ok("Se actualizó correctamente");
            }
            catch (IdCategorieException)
            {
                return BadRequest("El id es de una categoria inexistente");
            }
        }

        //Delete: api/Categories/3
        public IHttpActionResult Delete(int id)
        {
            try
            {
                categoriesLogic.Delete(id);
                return Ok("Se eliminó Correctamente");
            }
            catch (IdCategorieException)
            {
                return BadRequest("El id es de una categoria inexistente");
            }
            catch (Exception)
            {
                return BadRequest("No se puede eliminar una categoria que tiene otras entidades relacionadas");
            }
        }
    }
}
