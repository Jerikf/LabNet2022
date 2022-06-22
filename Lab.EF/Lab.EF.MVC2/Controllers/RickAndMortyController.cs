using Lab.EF.MVC2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC2.Controllers
{
    public class RickAndMortyController : Controller
    {
        // GET: RickAndMorty
        public async Task<ActionResult> Index()
        {
            List<RickMortyView> rickMortyViews = new List<RickMortyView>();
            //https://rickandmortyapi.com/api/character
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://rickandmortyapi.com/api/character");
            dynamic jsonList = JsonConvert.DeserializeObject(json);
            var result = jsonList.results;
            foreach(var item in result)
            {
                RickMortyView rickMorty = new RickMortyView()
                {
                    id = item.id,
                    name = item.name,
                    status = item.status,
                    species = item.species,
                    type = item.type,
                    gender = item.gender,
                    image = item.image
                };
                rickMortyViews.Add(rickMorty);
            }
            return View(rickMortyViews);
        }
    }
}