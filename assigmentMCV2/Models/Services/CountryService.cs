using assigmentMVC2.Models.Repos;
using assigmentMVC2.Models.ViewModels;
using System.Diagnostics.Metrics;

namespace assigmentMVC2.Models.Services
{
    public class CountryService : ICountryService
    {
        ICountryRepo _countriesRepo;
        ICityRepo _citiesRepo;
        public CountryService(ICountryRepo countriesRepo, ICityRepo citiesRepo)
        {
            _countriesRepo = countriesRepo;
            _citiesRepo = citiesRepo;
        }


        public CountryView Create(CreateCountryView createCountry)
        {
            if (createCountry == null)
            {
                throw new ArgumentException("You have to provide the country info..!");
            }

            if (createCountry.Cities == null || createCountry.Cities.Length < 1)
            {
                throw new ArgumentException("You have to provide the cities....");
            }


            List<City> cities = createCountry.Cities.Select(name => new City { Name = name }).ToList();
            //List<City> cities = createCountry.Cities.Where(City c => c.Id ).ToList();

            Country country = new Country
            {
                Name = createCountry.Name,
                Cities = cities
            };

            country = _countriesRepo.Create(country);

            CountryView result = new CountryView
            {
                Id = country.Id,
                Name = createCountry.Name,
                //Cities = country.Cities!.Select(c => c.Name!).ToList()
                //Cities = _citiesRepo.g
            };

            return result;
        }

        public CountryView? FindById(int id)
        {
            var country = _countriesRepo.GetById(id);

            if (country == null)
            {
                throw new ArgumentException("There is no country with this id..");
            }

            return new CountryView
            {
                Name = country!.Name,
                //Cities = country.Cities.Select(c => c.Name!).ToList()
                //Cities = country.Cities!.ToList()
            };
        }

        public List<CountryView> GetAll()
        {
            return _countriesRepo.GetAll()
                .Select(c => new CountryView
                {
                    Id = c.Id,
                    Name = c.Name,
                    Cities = c.Cities!.ToList()
            }).ToList();
        }
        /*public List<Country> FindByCities(string countries)
        {
            return _countriesRepo.GetByCities(countries);
        }*/

        public CountryView Edit(int id)
        {
            CountryView country = FindById(id);

            if (country != null)
            {
                throw new ArgumentException("There is no country with this id..");
            }

            return country;
            // return _countriesRepo.Update(country);
        }

        public bool Update(int id, CreateCountryView countryView)
        {
            /*Country orginalCountry = FindById(id);

            if (orginalCountry != null)
            {  
                orginalCountry.Name = editCountry.Name;
            }*/

            Country country = new Country
            {
                Id = id,
                Name = countryView.Name,
            };

            return _countriesRepo.Update(country);
            // return _countriesRepo.Update(country);
        }

        public bool Remove(int id)
        {
            Country countryToDelete = _countriesRepo.GetById(id);

            if (countryToDelete == null)
            {
                return false;
            }

            bool success = _countriesRepo.Delete(countryToDelete);

            return success;

        }
   

    }
}
