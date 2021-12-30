using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MVCBasics.Models
{
    public class Language
    {
        [Key] public int Id { get; set; }
        [MaxLength(100)] public string Name { get; set; }
        [IgnoreDataMember]
        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}