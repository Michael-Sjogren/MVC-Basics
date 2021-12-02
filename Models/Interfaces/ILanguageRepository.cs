using System.Collections.Generic;
using MVCBasics.ViewModels;

namespace MVCBasics.Models.Interfaces
{
    public interface ILanguageRepository
    {
        public List<Language> GetAllLanguages();
        public Language GetLanguageById(int id);
        public Language GetLanguageByName(string name);
        public void DeleteLanguageById(int id);

        public void CreateLanguage(CreateLanguageViewModel vm);
    }
}