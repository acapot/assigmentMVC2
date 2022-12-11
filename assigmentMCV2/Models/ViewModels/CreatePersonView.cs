using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assigmentMVC2.Models.ViewModels
{
    [BindProperties(SupportsGet = true)]
    public class CreatePersonView
    {

        [StringLength(50, MinimumLength = 3, ErrorMessage = "It Accepts only between 3 and 50 charecters")]
        [Required]
        public string? PersonName { get; set; }

        public string? PhoneNumber { get; set; }

        //[Required(ErrorMessage = "You have to add the City")]
        //[Display(Name = "City")]
       // public string? CityName { get; set; }
        public int CityId { get; set; }

        [Required(ErrorMessage = "You have to add languages....")]
        
        public List<CountryView> Countries { get; set; } = new List<CountryView>();      

    }
}
