using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.EF.Entities.ViewModel
{
    public class CategoriesProducts
    {
        public CategoriesProducts(Categories categories, List<Products> products)
        {
            Categories = categories;
            Products = products;
        }

        public Categories Categories { get; set; }
        public List<Products> Products { get; set; }

    }
}
