using assigmentMVC2.Models.Services;
using assigmentMVC2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace assigmentMVC2.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;

        public CountriesController(ICountryService countriesService, ICityService cityService)
        {
            _countryService = countriesService;
            _cityService = cityService; 
        }

        public IActionResult Index()
        {
            var result = _countryService.GetAll();
            return View(result);
        }

        public IActionResult Details(int id)
        {
            CountryView country = _countryService.FindById(id);
            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCountryView pv = new CreateCountryView();
            pv.Cities = _cityService.GetAll().Select(c=>c.Name).ToArray();


            return View(pv);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateCountryView createCountryView)
        {

            bool validCities = createCountryView.Cities == null || createCountryView.Cities.Length == 0;

            if (!ModelState.IsValid || validCities)
            {
                if (validCities)
                {
                    ModelState.AddModelError("citiesNames", "You have to add the cities");
                }

                return View(createCountryView);

            }


            _countryService.Create(createCountryView);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteView(int id)
        {
            CountryView country = _countryService.FindById(id);
            return View("~/Views/Country/Delete.cshtml", country);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var resutl = _countryService.Remove(id);

            if (!resutl)
            {
                return NotFound();
            }

            List<CountryView> countries = _countryService.GetAll();

            return PartialView("_CountriesTable", countries);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, CreateCountryView country)
        {

            if (ModelState.IsValid)
            {
                _countryService.Edit(id);
                return RedirectToAction(nameof(Index));
                //return NotFound();//404
            }

            return View(country);
        }


        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id)
        {
            CountryView country = _countryService.FindById(id);

            if (country == null)
            {
                return RedirectToAction(nameof(Index));
                //return NotFound();//404
            }
            CreateCountryView editCountry = new CreateCountryView()
            {
                Name = country.Name
                //CityName = _cityService.FindById(person.CityId).Name
            };

           // editPerson.Countries = _countryService.GetAll();

            return View(editCountry);
        }
    }
}
