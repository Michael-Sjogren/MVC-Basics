using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MVCBasics.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required] [DataType(DataType.Text)] [DisplayName("Full Name")] public string Name { get; set; }
        [Required] [DisplayName("City")] public int CityId { get; set; }
        [Required] public List<int> Languages { get; set; }

        [Required] [DataType(DataType.Text)] [DisplayName("Phone Number")] public string PhoneNumber { get; set; }
    }
}