namespace MVCBasics.ModelViews
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PeopleViewModel PeopoleVm { get; set; }
    }
}