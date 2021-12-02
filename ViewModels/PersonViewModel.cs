using System.Collections.Generic;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<LanguageViewModel> Languages { get; set; }
    }
}