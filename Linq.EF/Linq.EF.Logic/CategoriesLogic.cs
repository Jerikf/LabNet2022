using Linq.EF.Entities;
using Linq.EF.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.EF.Logic
{
    public class CategoriesLogic : BaseLogic
    {
        public List<CategoriesProducts> GetCategoriesAssocProducts()
        {
            var categoriesProductsAssoc = context.Categories.GroupJoin(context.Products, categorie => categorie.CategoryID, product => product.CategoryID, (categorie, product) => new { categorie, product }).ToList();
            return categoriesProductsAssoc.Select(valor => new CategoriesProducts(valor.categorie, (List<Products>)(valor.product))).ToList();
        }
    }
}
