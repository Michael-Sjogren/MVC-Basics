using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly ICountryRepository _countryRepository;

        public CityController(ICitiesRepository citiesRepository, ICountryRepository countryRepository)
        {
            _citiesRepository = citiesRepository;
            _countryRepository = countryRepository;
        }
        
        [HttpGet]
        [Route("/Cities/")]
        public IActionResult Index()
        {
            ViewBag.Countries = _countryRepository.GetAllCountries();
            return View(_citiesRepository.GetAllCities());
        }

        public IActionResult Create(CreateCityViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
            _citiesRepository.CreateCity(model);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _citiesRepository.DeleteCity(id);
            return RedirectToAction(nameof(Index));
        }
    }
}