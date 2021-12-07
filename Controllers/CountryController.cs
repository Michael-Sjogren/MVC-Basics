using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;


namespace MVCBasics.Controllers
{   
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        [Route("/Countries/")]
        public IActionResult Index()
        {
            return View(_countryRepository.GetAllCountries());
        }
        
        [HttpPost]
        public IActionResult Create(CreateCountryViewModel vm)
        {
            if (!ModelState.IsValid) 
                return RedirectToAction(nameof(Index));
            _countryRepository.CreateCountry(vm);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _countryRepository.DeleteCountry(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("/Countries/{id:int}")]
        public IActionResult CountryView(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            if (country != null)
            {
                var cvm = new CountryViewModel {Name  = country.Name , Id = country.Id};
                return View(cvm);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(UpdateCountryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _countryRepository.UpdateCountry(vm);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}