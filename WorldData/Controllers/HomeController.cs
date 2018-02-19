using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System.Collections.Generic;

namespace WorldData.Controllers
{
  public class HomeController : Controller
  {
    [Produces("text/html")]
      [HttpGet("/")]
      public ActionResult Index()
      {
          List<Country> AllCountrys = Country.GetAll();
          return View(AllCountrys);
      }

      [HttpPost("/filter-name")]
      public ActionResult Name()
        {
        string userInput = Request.Form["name"];
        List<Country> nameCountrys = Country.FilterCountry(userInput);
        return View("Index", nameCountrys);
        }

      [HttpPost("/filter-continent")]
      public ActionResult Continent()
        {
        List<Country> nameCountrys = Country.FilterContinent();
        return View("Index", nameCountrys);
        }

      [HttpPost("/filter-region")]
      public ActionResult Region()
        {
        List<Country> nameCountrys = Country.FilterRegion();
        return View("Index", nameCountrys);
        }

      [HttpPost("/filter-surface-area")]
      public ActionResult Surface()
        {
        List<Country> nameCountrys = Country.FilterSurface();
        return View("Index", nameCountrys);
        }

        [HttpPost("/filter-population")]
        public ActionResult Population()
          {
          List<Country> nameCountrys = Country.FilterPopulation();
          return View("Index", nameCountrys);
          }

  }
}
