using Linq.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.EF.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public List<Products> GetProductsOutStock()
        {
            return context.Products.Where(product => product.UnitsInStock == 0).ToList();
        }
        
        public List<Products> GetProductsWithStockAndCostMore3ByUnit()
        {
            var query = from product in context.Products
                        where (product.UnitsInStock > 0 && product.UnitPrice > 3)
                        select product;
            return query.ToList();
        }

        public Products GetProductFirtById789()
        {
            return context.Products.FirstOrDefault(product => product.CategoryID == 789);
        }

        public List<Products> GetProductsOrderByName()
        {
            var query = from product in context.Products
                        orderby product.ProductName
                        select product;
            return query.ToList();
        }

        public List<Products> GeteProductOrderByUnitStockDesc()
        {
            var query = from product in context.Products
                        orderby product.UnitsInStock descending
                        select product;
            return query.ToList();
        }

        public Products GetFirstProduct()
        {
            return context.Products.First();
        }

    }
}
