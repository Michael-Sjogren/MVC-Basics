using Microsoft.AspNetCore.Mvc;

namespace MVCBasics.Controllers
{
    public class CountryController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}