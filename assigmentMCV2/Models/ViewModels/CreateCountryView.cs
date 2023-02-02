
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace assigmentMVC2.Models.ViewModels
{
    public class CreateCountryView
    {
        [Required(ErrorMessage = "The name of country is required...!")]
        [Display(Name = "Name")]
        [BindProperty]
        public string? Name { get; set; }

        [Required]
        public string[]? Cities { get; set; }
    }
}
