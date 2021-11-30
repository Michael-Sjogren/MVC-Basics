using System.Collections.Generic;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class PeopleViewModel
    {
        public IEnumerable<Person> People { get; set; }
    }
}