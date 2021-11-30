using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class SearchPersonViewModel
    {
        [Required] [DataType(DataType.Text)] [DisplayName("Search")] public string SearchText { get; set; }
    }
}