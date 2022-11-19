using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assigmentMVC2.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "Person")]
        [Required]
        public string? PersonName { get; set; }
        public string? PhoneNumber { get; set; }        

        [Required]
        public string? City { get; set; }
      

        public List<string> CitiesList
        {
            get
            {
                return new List<string>

                { "Stockholm", "Växjö", "Göteborg","Linköping","Jönköping","Alvesta" };
            }
        }
    }
}
