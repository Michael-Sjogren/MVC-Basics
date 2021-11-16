namespace MVCBasics.Models
{
    public class Person
    {
        private static int _nextId = 0;
        public static int GetNextId => _nextId++;

        public Person()
        {
            Id = GetNextId;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }
}