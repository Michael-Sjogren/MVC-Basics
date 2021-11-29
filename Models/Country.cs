using System.ComponentModel.DataAnnotations;

namespace MVCBasics.Models
{
    public class Country
    {
        [Key] private string Name { get; set; }
    }
}