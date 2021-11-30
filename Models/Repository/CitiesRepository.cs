using System.Collections.Generic;
using System.Linq;
using MVCBasics.DataAccess;
using MVCBasics.Models.Interfaces;

namespace MVCBasics.Models.Repository
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly AppDbContext _context;
        public CitiesRepository(AppDbContext context)
        {
            this._context = context;
        }
        public List<City> GetAllCities()
        {
            return _context.Cities.ToList();
        }

        public City GetCityById(int id)
        {
            return _context.Cities.Find(id);
        }

        public City GetCityByName(string name)
        {
            return _context.Cities.First(e=>e.Name.Equals(name));
        }

        public void DeleteCity(int id)
        {
            var city = GetCityById(id);
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }
    }
}