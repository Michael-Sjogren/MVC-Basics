using System.Collections.Generic;

namespace MVCBasics.DTO
{
    public class PersonReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName { get; set; }
        public List<string> Languages { get; set; }
        public string CountryName { get; set; }
    }
}