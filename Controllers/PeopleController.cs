using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly ICitiesRepository _citiesRepository;

        public PeopleController(IPeopleRepository peopleRepository , ICitiesRepository citiesRepository)
        {
            _peopleRepository = peopleRepository;
            _citiesRepository = citiesRepository;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var model = new PeopleViewModel
            {
                People = _peopleRepository.GetAllPeople()
            };
            ViewBag.Cities = _citiesRepository.GetAllCities();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            if (!ModelState.IsValid) return View("_CreatePersonFormPartial", model);

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