using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MVCBasics.DataAccess;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;

namespace MVCBasics.Models.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppDbContext _context;

        public PeopleRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Person> GetAllPeople()
        {
            return _context.People.Include(person => person.City).ThenInclude(c => c.Country).ToList();
        }

        public Person GetPersonById(int id)
        {
            var p = _context.People.Find(id);
            var personLanguages = _context.PersonLanguages
                .Include(pl=>pl.Language)
                .Where(person => person.PersonId == id);
            p.City = _context.Cities.Find(p.CityId);
            p.City.Country = _context.Countries.Find(p.City.CountryId);
            p.PersonLanguages = personLanguages.ToList();
            return p;
        }

        public Person GetPersonByName(string name)
        {
            return _context.People.AsQueryable().First(e => e.Name.Equals(name));
        }

        public void DeletePersonById(int id)
        {
            var p = GetPersonById(id);
            if (p is null) return;
            _context.People.Remove(p);
            _context.SaveChanges();
        }
        
        public void CreatePerson(CreatePersonViewModel vm)
        {
            var newPerson = new Person
            {
                Name = vm.Name,
                City = _context.Cities.Find(vm.CityId),
                PhoneNumber = vm.PhoneNumber,
            };

            
            _context.People.Add(newPerson);
            _context.SaveChanges();

            foreach (var languagId in vm.Languages)
            {
                _context.PersonLanguages.Add(new PersonLanguage
                {
                    PersonId = newPerson.Id,
                    LanguageId = languagId
                });
                
            }
            _context.SaveChanges();
        }
    }
}