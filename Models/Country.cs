using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MVCBasics.Models
{
    public class Country
    {
        [Required] [Key] public int Id { get; set; }
        [Required] [MaxLength(100)] public string Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}