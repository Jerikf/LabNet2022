using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.EF.MVC2.Models
{
    public class CategoriesView
    {
        public int CategoriesId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}