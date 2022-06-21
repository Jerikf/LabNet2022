using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.EF.MVC2.Models
{
    public class CategoriesView
    {
        public int CategoryID { get; set; }
        
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}