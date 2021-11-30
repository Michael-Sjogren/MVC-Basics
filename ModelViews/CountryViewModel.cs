using System.Collections.Generic;
using MVCBasics.Models;

namespace MVCBasics.ModelViews
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityViewModel> Cities { get; set; }
    }
}