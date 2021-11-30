using Microsoft.AspNetCore.Mvc;

namespace MVCBasics.Controllers
{
    public class CityController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}