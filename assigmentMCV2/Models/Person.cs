using System.Xml.Linq;

namespace assigmentMVC2.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? PersonName { get; set; }
        public string? City { get; set; }
        public string PhoneNumber { get; set; }

        public Person(string? personName, string? phoneNumber, string? city)
        {

            PersonName = personName;
            PhoneNumber = phoneNumber;
            City = city;
        }
        public Person()
        {}
    }
}
