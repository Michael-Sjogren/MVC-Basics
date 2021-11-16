

namespace MVCBasics.Models
{
    public class Person
    {
        public Person()
        {
            Id = PersonIdSequencer.NextPersonId;
        }
        public int Id { get; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }
}