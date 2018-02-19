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

  }
}
