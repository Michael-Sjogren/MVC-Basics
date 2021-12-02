using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        // GET
        [HttpGet]
        [Route("/Languages/")]
        public IActionResult Index()
        {
            var languagesVm = new List<LanguageViewModel>();
            foreach (var language in _languageRepository.GetAllLanguages())
            {
                languagesVm.Add(new LanguageViewModel
                {
                    Name = language.Name,
                    Id = language.Id
                });                
            }
            return View(languagesVm);
        }

        [HttpPost]
        public IActionResult Create(CreateLanguageViewModel model)
        {
            ViewBag.Cities = _languageRepository.GetAllLanguages();
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            _languageRepository.CreateLanguage(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _languageRepository.DeleteLanguageById(id);
            return  RedirectToAction(nameof(Index));
        }
    }
}