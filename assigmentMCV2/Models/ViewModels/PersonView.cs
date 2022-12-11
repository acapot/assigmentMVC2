using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assigmentMVC2.Models.ViewModels
{
    [BindProperties(SupportsGet = true)]
    public class PersonView
    {
        public int Id { get; set; }
        public string? PersonName { get; set; }
        public string? PhoneNumber { get; set; }
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        [ValidateNever]
        public int CityId { get; set; }
    }
}
