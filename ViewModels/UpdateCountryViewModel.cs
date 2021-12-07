using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class UpdateCountryViewModel
    {

        public int Id { get; set; }
        [DataType(DataType.Text)] [Display(Name = "Country Name")]
        public string Name { get; set; }
    }
}