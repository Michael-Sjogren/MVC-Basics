using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly ICitiesRepository _citiesRepository;
        private readonly ICitiesRepository _personLanguages;

        public PeopleController(IPeopleRepository peopleRepository, ICitiesRepository citiesRepository)
        {
            _peopleRepository = peopleRepository;
            _citiesRepository = citiesRepository;
        }

        // GET
        [HttpGet]
        [Route("/People/")]
        public IActionResult Index()
        {
            var model = new PeopleViewModel
            {
                People = _peopleRepository.GetAllPeople().OrderBy(person => person.Id).ToList()
            };
            ViewBag.Cities = _citiesRepository.GetAllCities();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            ViewBag.Cities = _citiesRepository.GetAllCities();
            if (!ModelState.IsValid) return View("_CreatePersonFormPartial", model);

            _peopleRepository.CreatePerson(model);
            return Redirect("/People/");
        }
        [HttpGet]
        [HttpDelete]
        [Route("/People/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            _peopleRepository.DeletePersonById(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(SearchPersonViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
            var comparator = StringComparison.CurrentCultureIgnoreCase;
            var vm = new PeopleViewModel
            {
                People = _peopleRepository
                    .GetAllPeople()
                    .FindAll(p =>
                        p.Name.Contains(model.SearchText, comparator) ||
                        p.City.Name.Contains(model.SearchText, comparator)
                    )
            };
            Console.WriteLine(vm.People.ToArray());
            return View("Index", vm);
        }

        [HttpGet]
        [Route("/People/{id:int}")]
        public IActionResult PersonView(int id)
        {
            var p = _peopleRepository.GetPersonById(id);
            var languagesVm =
                p.PersonLanguages.Select(pl => new LanguageViewModel {Name = pl.Language.Name, Id = pl.Language.Id})
                    .ToList();
            var pvm = new PersonViewModel
            {
                Id = p.Id,
                Phone = p.PhoneNumber,
                Name = p.Name,
                Languages = languagesVm
            };
            return View(pvm);
        }
    }
}