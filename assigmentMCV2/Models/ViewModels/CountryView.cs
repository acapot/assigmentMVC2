namespace assigmentMVC2.Models.ViewModels
{
    public class CountryView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();

    }
}
