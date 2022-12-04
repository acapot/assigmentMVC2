using System.ComponentModel.DataAnnotations;

namespace assigmentMVC2.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the name of the city please..")]
        public string? Name { get; set; }

        public int CountryId { get; set; }
        [Required]
        public Country? Country { get; set; }
        public List<Person>? Persons { get; set; }

        public City(string? name)
        {

            Name = name;
        }
        public City()
        { }
    }
}
