
using System.Collections.Generic;

namespace MVCBasics.DTO
{
    public class CreatePersonDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public List<int> Languages { get; set; }

    }
}