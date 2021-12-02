using System.Collections.Generic;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class PersonLanguageViewModel
    {
        public Person Person { get; set; }
        public List<Language> Languages { get; set; }

    }
}