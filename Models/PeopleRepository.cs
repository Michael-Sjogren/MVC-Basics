using System.Collections.Generic;
using System.Linq;
using MVCBasics.Models.Interfaces;
using MVCBasics.ModelViews;

namespace MVCBasics.Models
{
    public class PeopleRepository : IPeopleRepository
    {
        public List<Person> People { get; set; }

        public PeopleRepository()
        {
            People = new List<Person>{
                new() {Name = "Jens", City = "Malmö" , PhoneNumber = "07328214"},
                new() {Name = "Per" , City = "London" , PhoneNumber = "0732821432"},
                new() {Name = "Johan" , City = "Kiruna" , PhoneNumber = "0732438214 "},
                new() {Name = "Alex" , City = "Skövde" , PhoneNumber = "07328214"},
                new() {Name = "Sofia" , City = "Stockholm" , PhoneNumber = "07328214"},
                new() {Name = "Kerstin", City = "Göteborg", PhoneNumber = "07328214"},
            };
        }

        public List<Person> GetAllPeople()
        {
            return People;
        }

        public Person GetPersonById(int id)
        {
            return People.First(e => e.Id == id);
        }

        public Person GetPersonByName(string name)
        {
            return People.First(e => e.Name.Equals(name));
        }

        public void DeletePersonById(int id)
        {
            var p = GetPersonById(id);
            People = People.Where(person => person.Id == p.Id ).ToList();
        }

        public void CreatePerson(CreatePersonViewModel vm)
        {
            var newPerson = new Person
            {
                Name = vm.Name,
                City = vm.City,
                PhoneNumber = vm.PhoneNumber
            };
            
            People.Add(newPerson);
        }
    }
}