using System.Collections.Generic;
using System.Linq;
using MVCBasics.Models.Interfaces;
using MVCBasics.ModelViews;

namespace MVCBasics.Models
{
    public class PeopleRepository : IPeopleRepository
    {
        private static List<Person> _people = new (){
            new Person {Name = "Jens", City = "Malmö" , PhoneNumber = "07328214"},
            new Person {Name = "Per" , City = "London" , PhoneNumber = "0732821432"},
            new Person {Name = "Johan" , City = "Kiruna" , PhoneNumber = "0732438214 "},
            new Person {Name = "Alex" , City = "Skövde" , PhoneNumber = "07328214"},
            new Person {Name = "Sofia" , City = "Stockholm" , PhoneNumber = "07328214"},
            new Person {Name = "Kerstin", City = "Göteborg", PhoneNumber = "07328214"},
        };
        
        public List<Person> GetAllPeople()
        {
            return _people;
        }

        public Person GetPersonById(int id)
        {
            return _people.FirstOrDefault(e => e.Id == id);
        }

        public Person GetPersonByName(string name)
        {
            return _people.FirstOrDefault(e => e.Name.Equals(name));
        }

        public void DeletePersonById(int id)
        {
            var p = GetPersonById(id);
            if (p is null) return;
            _people = _people.Where(person => person.Id != p.Id ).ToList();
        }

        public void CreatePerson(CreatePersonViewModel vm)
        {
            var newPerson = new Person
            {
                Name = vm.Name,
                City = vm.City,
                PhoneNumber = vm.PhoneNumber
            };
            
            _people.Add(newPerson);
        }
    }
}