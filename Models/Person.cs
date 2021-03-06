using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.Models
{
    public class Person
    {
        [Required] [Key] public int Id { get; set; }
        [Required] [MaxLength(200)]public string Name { get; set; }
        [Required] [MaxLength(15)] public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        [Required] public City City { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}