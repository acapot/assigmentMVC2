using assigmentMVC2.Data;
using assigmentMVC2.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace assigmentMVC2.Models.Repos
{
    public class CityRepo : ICityRepo
    {
        public AppDbContext _appDbContext;

        public CityRepo(AppDbContext peopleDbContext)
        {
            _appDbContext = peopleDbContext;
        }

        public City Create(City city)
        {            
            _appDbContext.Add(city);
            _appDbContext.SaveChanges();
            return city;
        }

        public City Create(string name)
        {
            City city = new City(name);
            var result = _appDbContext.Cities!.Add(city).Entity;
            _appDbContext.Add(city);
            _appDbContext.SaveChanges();
            return result;
        }

        public List<City> GetAll()
        {
            
            List<City> cityList = new List<City>();
            cityList = _appDbContext.Cities!.ToList();
            return cityList;
        }


        public List<City>? GetAllCitiesByCountryId(int id)
        {

            List<City> cityList = new List<City>();
            cityList = _appDbContext.Cities!.Where(c=>c.Id == id).ToList();
            return cityList;
        }

        public City GetById(int id)
        {
            //City city = null;
            /*City city = _appDbContext.City.Where(p => p.Id == id);
            foreach (City aCity in cityList)
            {
                if (aCity.Id == id)
                {
                    city = aCity;
                    break;
                }
            }*/
            return _appDbContext.Cities.SingleOrDefault(p => p.Id == id);
        }

        public bool Update(City city)
        {
            City orginalCity = GetById(city.Id);
            if (orginalCity != null)
            {
                orginalCity.Name = city.Name;
                _appDbContext.Update(orginalCity);
                _appDbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(City city)
        {
            //return cityList.Remove(city);
            if (city != null)
            {
                _appDbContext.Remove(city);
                _appDbContext.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
