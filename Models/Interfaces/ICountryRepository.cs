using System.Collections.Generic;
using MVCBasics.ViewModels;

namespace MVCBasics.Models.Interfaces
{
    public interface ICountryRepository
    {
        public List<Country> GetAllCountries();
        public Country GetCountryById(int id);
        public Country GetCountryByName(string name);
        public void DeleteCountry(int id);

        public void CreateCountry(CreateCountryViewModel vm);
        public void UpdateCountry(UpdateCountryViewModel vm);
    }
}