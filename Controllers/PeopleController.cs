using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Models.Interfaces;
using MVCBasics.ModelViews;

namespace MVCBasics.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var model = new PeopleViewModel
            {
                People = _peopleRepository.GetAllPeople()
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            _peopleRepository.CreatePerson(model);
            return View("Index", new PeopleViewModel{People = _peopleRepository.GetAllPeople()});
        }
        
        [HttpPost]
        public IActionResult Search(string name)
        {
            
            return View("Index");
        }
    }
}