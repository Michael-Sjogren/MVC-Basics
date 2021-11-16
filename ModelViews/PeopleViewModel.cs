using System.Collections.Generic;
using MVCBasics.Models;

namespace MVCBasics.ModelViews
{
    public class PeopleViewModel
    {
        public IEnumerable<Person> People { get; set; }
    }
}