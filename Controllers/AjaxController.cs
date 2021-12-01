using System;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly ICitiesRepository _citiesRepository;
        public AjaxController(IPeopleRepository peopleRepository, ICitiesRepository citiesRepository)
        {
            _peopleRepository = peopleRepository;
            _citiesRepository = citiesRepository;
        }
        
        [HttpGet]
        [Route("/Ajax/")]
        public IActionResult Index()
        {
            ViewBag.Cities = _citiesRepository.GetAllCities();
            return View(new PeopleViewModel{ People = _peopleRepository.GetAllPeople()});
        }

        // GET
        [HttpGet]
        public IActionResult GetPeopleList()
        {
            return PartialView("_PeopleListPartial",_peopleRepository.GetAllPeople());
        }
        
        [HttpPost]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _peopleRepository.DeletePersonById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Search(SearchPersonViewModel model)
        {
            if (!ModelState.IsValid) return NotFound();
            var comp = StringComparison.OrdinalIgnoreCase;
            var list =_peopleRepository
                .GetAllPeople()
                .FindAll(p =>
                    p.Name.Contains(model.SearchText, comp) ||
                    p.Id.ToString().Equals(model.SearchText, comp) ||
                    p.City.Name.Contains(model.SearchText, comp)
                );
            
            return PartialView("_PeopleListPartial",list);
        }
    }
}