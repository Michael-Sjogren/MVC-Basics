using System.Collections.Generic;
using System.Linq;
using MVCBasics.DataAccess;
using MVCBasics.Models.Interfaces;
using MVCBasics.ModelViews;

namespace MVCBasics.Models
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PeopleContext _context;

        public PeopleRepository(PeopleContext context)
        {
            _context = context;
        }
        public List<Person> GetAllPeople()
        {
            return _context.People.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.People.Find(id);
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
                City = vm.City,
                PhoneNumber = vm.PhoneNumber
            };
            
            _context.People.Add(newPerson);
            _context.SaveChanges();
        }
    }
}