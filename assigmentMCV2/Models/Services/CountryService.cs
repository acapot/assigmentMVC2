using assigmentMVC2.Models.Repos;
using assigmentMVC2.Models.ViewModels;

namespace assigmentMVC2.Models.Services
{
    public class CountryService : ICountryService
    {
        ICountryRepo _countriesRepo;
        public CountryService(ICountryRepo countriesRepo)
        {
            _countriesRepo = countriesRepo;
        }
        public Country Create(CountryView createCountry)
        {
            if (string.IsNullOrWhiteSpace(createCountry.Name))
            { throw new ArgumentException("CountryName, Country allowed whitespace"); }

            Country country = new Country() { Name = createCountry.Name};
            country = _countriesRepo.Create(country);
            return country;
        }

        public Country FindById(int id)
        {
            return _countriesRepo.GetById(id);
        }
        public List<Country> GetAll()
        {
            return _countriesRepo.GetAll();
        }
        /*public List<Country> FindByCities(string countries)
        {
            return _countriesRepo.GetByCities(countries);
        }*/


        public bool Edit(int id, CountryView editCountry)
        {
            Country orginalCountry = FindById(id);
            if (orginalCountry != null)
            {  
                orginalCountry.Name = editCountry.Name;
            }
            return _countriesRepo.Update(orginalCountry);
            // return _countriesRepo.Update(country);
        }

        public bool Remove(int id)
        {
            Country countryToDelete = _countriesRepo.GetById(id);
            bool success = _countriesRepo.Delete(countryToDelete);

            return success;

        }
   

    }
}
