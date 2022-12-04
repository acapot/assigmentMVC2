using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assigmentMVC2.Models.ViewModels
{
    public class PersonView
    {
        [Display(Name = "Person")]
        [Required]
        public string? PersonName { get; set; }
        public string? PhoneNumber { get; set; }
        public int CityCode { get; set; }

        [Required]
        [Display(Name = "Country")]
        public IEnumerable<SelectListItem> Countries { get; set; }

        [Required]
        [Display(Name = "City")]
        public IEnumerable<SelectListItem> Cities { get; set; }

        /*public List<string> CitiesList
        {
            get
            {
                return new List<string>

                { "Stockholm", "Växjö", "Göteborg","Linköping","Jönköping","Alvesta" };
            }
        }*/
    }
}
