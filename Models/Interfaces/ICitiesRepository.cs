using System.Collections.Generic;
using MVCBasics.ViewModels;

namespace MVCBasics.Models.Interfaces
{
    public interface ICitiesRepository
    {
        public List<City> GetAllCities();
        public City GetCityById(int id);
        public City GetCityByName(string name);
        public void DeleteCity(int id);

        public void CreateCity(CreateCityViewModel vm);
    }
}