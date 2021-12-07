using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class UpdateCityViewModel
    {
        [Required] public int Id { get; set; }
        [Required] [DataType(DataType.Text)] [DisplayName("City Name")] public string Name { get; set; }
        [Required] [DisplayName("Country")] public int CountryId { get; set; }

    }
}