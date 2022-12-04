using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assigmentMVC2.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string? PersonName { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        public string? PhoneNumber { get; set; }

        public Person(string? personName, string? phoneNumber, City? city)
        {
            PersonName = personName;
            PhoneNumber = phoneNumber;
            City = city;
        }
        public Person()
        {}
    }
}
