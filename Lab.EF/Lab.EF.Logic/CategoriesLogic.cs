using Lab.EF.Common;
using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories>
    {

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public void Add(Categories newCategorie)
        {
            context.Categories.Add(newCategorie);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            
            var categorieAEliminar = context.Categories.Find(id);
            if (categorieAEliminar == null) throw new IdCategorieException(); // en caso de no existir un id podremos controlarlo desde UI
            context.Categories.Remove(categorieAEliminar);
            context.SaveChanges();
            //Falta ver como controlar cuando cuando se quiere eliminar por cascada -- Controlaremos con un try - cath "genérico"
        }

        public void Update(Categories categorie)
        {
            //NO SE ESTÁ USANDO EL CAMPO PICTURE QUE HACE REFERENCIA A BITE[] (tengo que investigar más de eso)
            var categorieUpdate = context.Categories.Find(categorie.CategoryID);
            if(categorieUpdate == null) throw new IdCategorieException();
            //se podría usar AUTOMAPPERS ? (AVERIGUARLO)
            categorieUpdate.CategoryID = categorie.CategoryID;
            categorieUpdate.CategoryName = categorie.CategoryName;
            categorieUpdate.Description = categorie.Description;
            context.SaveChanges();
        }

    }
}
