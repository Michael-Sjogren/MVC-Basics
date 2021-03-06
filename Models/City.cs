using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.Models
{
    public class City
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public List<Person> People { get; set; }

        public int CountryId { get; set; }
        [Required] public Country Country { get; set; }

    }
}