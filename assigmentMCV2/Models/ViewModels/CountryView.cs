using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace assigmentMVC2.Models.ViewModels
{
    public class CountryView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //[ValidateNever]
        public List<City> Cities { get; set; } = new List<City>();
        //[ValidateNever]
        //public List<SelectListItem> SelectCities { get; set; } = new List<SelectListItem>();

    }
}
