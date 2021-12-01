using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MVCBasics.DataAccess;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;

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
            return _context.Cities.Include(c => c.Country).ToList();
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

        public void CreateCity(CreateCityViewModel vm)
        {
            _context.Cities.Add(
                new City{Name = vm.Name , Country = _context.Countries.Find(vm.CountryId)}
                );
            _context.SaveChanges();
        }
    }
}