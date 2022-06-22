using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.EF.WebApi.Models
{
    public class CategorieView
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}