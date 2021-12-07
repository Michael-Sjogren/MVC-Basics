using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly ICitiesRepository _citiesRepository;
        private readonly ILanguageRepository _languagesRepository;

        public PeopleController(IPeopleRepository peopleRepository, ICitiesRepository citiesRepository,
            ILanguageRepository languagesRepository)
        {
            _peopleRepository = peopleRepository;
            _citiesRepository = citiesRepository;
            _languagesRepository = languagesRepository;
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
            ViewBag.Languages = _languagesRepository.GetAllLanguages();
            return View(model);
        }
        

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            ViewBag.Cities = _citiesRepository.GetAllCities();
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            _peopleRepository.CreatePerson(model);
            return RedirectToAction(nameof(Index));
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
            var languages = _languagesRepository.GetAllLanguages();
            var cities = _citiesRepository.GetAllCities();
            ViewBag.Cities = cities;
            ViewBag.Languages = languages;

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
        [HttpPost]
        [Route("/People/Update")]
        public IActionResult Update(EditPersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                _peopleRepository.UpdatePerson(model);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}