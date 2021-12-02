using System.Collections.Generic;
using System.Linq;
using MVCBasics.DataAccess;
using MVCBasics.Models.Interfaces;
using MVCBasics.ViewModels;

namespace MVCBasics.Models.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext _context;

        public LanguageRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Language> GetAllLanguages()
        {
            return _context.Languages.ToList();
        }

        public Language GetLanguageById(int id)
        {
            return _context.Languages.Find(id);
        }

        public Language GetLanguageByName(string name)
        {
            return _context.Languages.First(l => l.Name.Equals(name));
        }

        public void DeleteLanguageById(int id)
        {
            _context.Languages.Remove(GetLanguageById(id));
            _context.SaveChanges();
        }

        public void CreateLanguage(CreateLanguageViewModel vm)
        {
            _context.Languages.Add(
                new Language()
                {
                    Name = vm.Name
                });
            _context.SaveChanges();
        }
    }
}