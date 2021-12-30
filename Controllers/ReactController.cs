using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.DTO;
using MVCBasics.Models;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;
using Newtonsoft.Json;

namespace MVCBasics.Controllers
{
    public class ReactController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly ILanguageRepository _languageRepo;
        private readonly ICitiesRepository _citiesRepository;


        public ReactController(IPeopleRepository peopleRepository, ILanguageRepository languageRepo,
            ICitiesRepository citiesRepository)
        {
            _peopleRepository = peopleRepository;
            _languageRepo = languageRepo;
            _citiesRepository = citiesRepository;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/React/People")]
        public IActionResult GetPeople()
        {
            var people = _peopleRepository.GetAllPeople();
            var peopleDtos = new List<PersonReadDTO>();
            foreach (var p in people)
            {
                peopleDtos.Add(
                    new PersonReadDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        CityName = p.City.Name,
                        CountryName = p.City.Country.Name,
                        PhoneNumber = p.PhoneNumber,
                        Languages = new List<string>()
                    }
                );
            }

            return Ok(JsonConvert.SerializeObject(peopleDtos));
        }

        [HttpGet]
        [Route("/React/People/{Id:int}")]
        public IActionResult GetPerson(int Id)
        {
            Person p = _peopleRepository.GetPersonById(Id);
            var languages = new List<string>();
            foreach (var pl in p.PersonLanguages)
            {
                languages.Add(pl.Language.Name);
            }

            var personDto = new PersonReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                CityName = p.City.Name,
                PhoneNumber = p.PhoneNumber,
                CountryName = p.City.Country.Name,
                Languages = languages
            };
            return Ok(JsonConvert.SerializeObject(personDto));
        }

        [HttpPost]
        [Route("/React/People/Create")]
        public IActionResult CreatePerson([FromBody] CreatePersonViewModel personVm)
        {
            _peopleRepository.CreatePerson(personVm);
            return Ok();
        }

        [HttpDelete]
        [Route("/React/People/{Id:int}")]
        public IActionResult DeletePerson(int Id)
        {
            try
            {
                _peopleRepository.DeletePersonById(Id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/React/Cities")]
        public IActionResult GetCities()
        {
            var cities = _citiesRepository.GetAllCities();
            var cititesReadDtos = new List<CityReadDTO>(cities.Count);
            foreach (var city in cities)
            {
                cititesReadDtos.Add(
                    new CityReadDTO
                    {
                        Name = city.Name,
                        Id = city.Id,
                        CountryId = city.CountryId,
                        CountryName = city.Country.Name
                    }
                );
            }

            return Ok(JsonConvert.SerializeObject(cititesReadDtos));
        }

        [HttpGet]
        [Route("/React/Languages")]
        public IActionResult GetLanguages()
        {
            var languages = _languageRepo.GetAllLanguages();
            var languagesReadDtos = new List<LanguageReadDTO>(languages.Count);
            foreach (var language in languages)
            {
                languagesReadDtos.Add(
                    new LanguageReadDTO
                    {
                        Name = language.Name,
                        Id = language.Id
                    }
                );
            }

            return Ok(JsonConvert.SerializeObject(languagesReadDtos));
        }
    }
}