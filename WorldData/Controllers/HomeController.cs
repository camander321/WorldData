using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View("Index", Country.GetAll());
    }

    [HttpPost("/")]
    public ActionResult All()
    {
      return View("Index", Country.GetAll());
    }

    [HttpPost("/name")]
    public ActionResult Name()
    {
      string countryCheck = Request.Form["input1"];
      return View("Index", Country.GetName(countryCheck));
    }

    [HttpPost("/continent")]
    public ActionResult Continent()
    {
      string countryCheck = Request.Form["input1"];
      return View("Index", Country.GetContinent(countryCheck));
    }

    [HttpPost("/pop")]
    public ActionResult Population()
    {
      int minPopCheck = int.Parse(Request.Form["input1"]);
      int maxPopCheck = int.Parse(Request.Form["input2"]);
      return View("Index", Country.GetPop(minPopCheck, maxPopCheck));
    }
  }
}
