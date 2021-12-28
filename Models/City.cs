using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MVCBasics.Models
{
    public class City
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [IgnoreDataMember] [Required] public List<Person> People { get; set; }

        public int CountryId { get; set; }
        [Required] public Country Country { get; set; }

    }
}