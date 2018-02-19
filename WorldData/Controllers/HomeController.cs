using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View("Index", City.GetAll());
    }

    [HttpPost("/country")]
    public ActionResult Country()
    {
      string countryCheck = Request.Form["country"];
      return View("Index", City.GetCountry(countryCheck));
    }

    [HttpPost("/pop")]
    public ActionResult Population()
    {
      int minPopCheck = int.Parse(Request.Form["minPop"]);
      int maxPopCheck = int.Parse(Request.Form["maxPop"]);
      return View("Index", City.GetPop(minPopCheck, maxPopCheck));
    }
  }
}
