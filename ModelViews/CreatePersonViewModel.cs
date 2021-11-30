using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVCBasics.Models;

namespace MVCBasics.ModelViews
{
    public class CreatePersonViewModel
    {
        [Required] [DataType(DataType.Text)] [DisplayName("Full Name")] public string Name { get; set; }
        [Required] [DataType(DataType.Text)] [DisplayName("City")] public string City { get; set; }
        [Required] [DataType(DataType.Text)] [DisplayName("Phone Number")] public string PhoneNumber { get; set; }
    }
}