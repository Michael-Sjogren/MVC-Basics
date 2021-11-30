using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class CreateCityViewModel
    {
        [Required] [DataType(DataType.Text)] [DisplayName("Country Name")] public string Name { get; set; }
    }
}