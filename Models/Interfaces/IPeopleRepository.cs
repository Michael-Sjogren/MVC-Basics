using System.Collections.Generic;
using MVCBasics.ViewModels;


namespace MVCBasics.Models.Interfaces
{
    public interface IPeopleRepository
    {
        public List<Person> GetAllPeople();
        public Person GetPersonById(int id);
        public Person GetPersonByName(string name);
        public void DeletePersonById(int id);

        public void CreatePerson(CreatePersonViewModel vm);
    }
}