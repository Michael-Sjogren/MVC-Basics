using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models.Interfaces;
using Newtonsoft.Json;
namespace MVCBasics.Controllers
{
    public class ReactController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;

        public ReactController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/React/People")]
        public IActionResult GetPeople()
        {
            var people = _peopleRepository.GetAllPeople();
            return Ok(JsonConvert.SerializeObject(people));
        }
    }
}