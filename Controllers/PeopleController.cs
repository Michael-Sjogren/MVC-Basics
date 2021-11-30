using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.DataAccess;
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
            if (!ModelState.IsValid) return View("_CreatePersonForm", model);

            _peopleRepository.CreatePerson(model);
            return Redirect("/People/");
        }

        public IActionResult Delete(int id)
        {
            _peopleRepository.DeletePersonById(id);
            return Redirect("/People/");
        }

        [HttpPost]
        public IActionResult Search(SearchPersonViewModel model)
        {
            if (!ModelState.IsValid) return Redirect("/People/");
            var comparator = StringComparison.CurrentCultureIgnoreCase;
            var vm = new PeopleViewModel
            {
                People = _peopleRepository
                    .GetAllPeople()
                    .FindAll(p =>
                        p.Name.Contains(model.SearchText, comparator) ||
                        p.City.Name.Contains(model.SearchText , comparator)
                    )
            };
            Console.WriteLine(vm.People.ToArray());
            return View("Index", vm);
        }
    }
}