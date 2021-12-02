using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Required] [DataType(DataType.Time)] [MaxLength(150)] public string Name { get; set; }
    }
}