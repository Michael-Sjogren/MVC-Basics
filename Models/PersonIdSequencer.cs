namespace MVCBasics.Models
{
    public static class PersonIdSequencer
    {
        private static int _currentId = 1;
        public static int NextPersonId
        {
            get => _currentId++;
        }
        
    }
}