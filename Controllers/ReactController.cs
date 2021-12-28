using Microsoft.AspNetCore.Mvc;

namespace MVCBasics.Controllers
{
    public class ReactController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}