using System.ComponentModel.DataAnnotations;

namespace MVCBasics.Models
{
    public class City
    {
        [Key] public string Name { get; set; }
        
    }
}