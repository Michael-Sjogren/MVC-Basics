using System.Collections.Generic;
using System.Linq;
using MVCBasics.DataAccess;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;

namespace MVCBasics.Models.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;
        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public List<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.Find(id);
        }

        public Country GetCountryByName(string name)
        {
            return _context.Countries.First(c => c.Name.Equals(name));
        }

        public void DeleteCountry(int id)
        {
            _context.Countries.Remove(GetCountryById(id));
            _context.SaveChanges();
        }

        public void CreateCountry(CreateCountryViewModel vm)
        {
            _context.Countries.Add(
                new Country(){Name = vm.Name}
            );
            _context.SaveChanges();
        }

        public void UpdateCountry(UpdateCountryViewModel vm)
        {
            var country = GetCountryById(vm.Id);
            if (country != null)
            {
                country.Name = vm.Name;
            }
            _context.SaveChanges();
        }
    }
}