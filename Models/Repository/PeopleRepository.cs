using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
            return _context.People.Include(person => person.City).ToList();
        }

        public Person GetPersonById(int id)
        {
            var p = _context.People.Find(id);
            if (p == null) return null;
            _context.Entry(p).Collection( pl => pl.PersonLanguages).Load();
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

            foreach (var languageId in vm.Languages)
            {
                _context.PersonLanguages.Add(new PersonLanguage
                {
                    PersonId = newPerson.Id,
                    LanguageId = languageId
                });
                
            }
            _context.SaveChanges();
        }


        public void UpdatePerson(EditPersonViewModel vm )
        {
            var p = GetPersonById(vm.Id);
            if (p != null)
            {
                p.Name = vm.Name;
                p.PhoneNumber = vm.PhoneNumber;
                p.CityId = vm.CityId;
                
                _context.PersonLanguages.RemoveRange(p.PersonLanguages);
                _context.SaveChanges();

                foreach (var languageId in vm.Languages)
                {
                    _context.PersonLanguages.Add(new PersonLanguage
                    {
                        PersonId = p.Id,
                        LanguageId = languageId
                    });
                
                }

                _context.SaveChanges();
            }
        }
    }
}