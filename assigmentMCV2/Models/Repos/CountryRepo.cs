using assigmentMVC2.Data;
using Microsoft.EntityFrameworkCore;

namespace assigmentMVC2.Models.Repos
{
    public class CountryRepo : ICountryRepo
    {
        public AppDbContext _appDbContext;

        public CountryRepo(AppDbContext peopleDbContext)
        {
            _appDbContext = peopleDbContext;
        }

    
        public Country Create(Country country)
        {
            var result = _appDbContext.Countries!.Add(country).Entity;
            _appDbContext.Add(country);
            _appDbContext.SaveChanges();
            return result;
        }

        public List<Country> GetAll()
        {
            
            List<Country> countryList = new List<Country>();
            countryList = _appDbContext.Countries!
                .Include(c => c.Cities)
                .ToList();
            return countryList;
        }




        public Country? GetById(int id)
        {
            //Country country = null;
            /*Country country = _appDbContext.Country.Where(p => p.Id == id);
            foreach (Country aCountry in countryList)
            {
                if (aCountry.Id == id)
                {
                    country = aCountry;
                    break;
                }
            }*/
            return _appDbContext.Countries!.Find(id);
            //return _appDbContext.Countries.SingleOrDefault(p => p.Id == id);
        }

        public bool Update(Country country)
        {
            Country orginalCountry = GetById(country.Id);
            if (orginalCountry != null)
            {
                orginalCountry.Name = country.Name;
                _appDbContext.Update(orginalCountry);
                _appDbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(Country country)
        {
            //return countryList.Remove(country);
            if (country != null)
            {
                _appDbContext.Remove(country);
                _appDbContext.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
