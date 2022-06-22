using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.EF.MVC2.Models
{
    public class RickMortyView
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public string image { get; set; }
    }
}