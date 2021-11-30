using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required] [DataType(DataType.Text)] [DisplayName("Full Name")] public string Name { get; set; }
        [Required] [DisplayName("City")] public int CityId { get; set; }
        [Required] [DataType(DataType.Text)] [DisplayName("Phone Number")] public string PhoneNumber { get; set; }
    }
}