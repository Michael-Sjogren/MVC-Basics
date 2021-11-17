using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Models.Interfaces;
using MVCBasics.ModelViews;

namespace MVCBasics.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;

        public AjaxController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        [HttpGet]
        [Route("/Ajax/")]
        public IActionResult Index()
        {
            return View(new PeopleViewModel{ People = _peopleRepository.GetAllPeople()});
        }

        // GET
        [HttpGet]
        public IActionResult GetPeopleList()
        {
            return PartialView("_PeopleList",_peopleRepository.GetAllPeople());
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
                    p.City.Contains(model.SearchText, comp)
                );
            
            return PartialView("_PeopleList",list);
        }
    }
}