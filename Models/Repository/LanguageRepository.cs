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
            throw new System.NotImplementedException();
        }

        public Language GetLanguageByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLanguageById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CreateLanguage(CreateLanguageViewModel vm)
        {
            throw new System.NotImplementedException();
        }
    }
}