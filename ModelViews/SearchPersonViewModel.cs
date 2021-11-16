using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ModelViews
{
    public class SearchPersonViewModel
    {
        [Required] [DataType(DataType.Text)] [DisplayName("Search")] public string SearchText { get; set; }
    }
}