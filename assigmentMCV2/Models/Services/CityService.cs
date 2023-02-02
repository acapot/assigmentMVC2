using assigmentMVC2.Data;
using assigmentMVC2.Models.Repos;
using assigmentMVC2.Models.ViewModels;

namespace assigmentMVC2.Models.Services
{
    public class CityService : ICityService
    {
        ICityRepo _citiesRepo;
        public CityService(ICityRepo citiesRepo)
        {
            _citiesRepo = citiesRepo;
        }
        public City Create(CityView createCity)
        {
            if (string.IsNullOrWhiteSpace(createCity.Name))
            { throw new ArgumentException("CityName, City allowed whitespace"); }

            City city = new City(createCity.Name);
            city = _citiesRepo.Create(city);
            return city;
        }

        public City FindById(int id)
        {
            return _citiesRepo.GetById(id);
        }
        public List<City> GetAll()
        {
            return _citiesRepo.GetAll();
        }
        /*public List<City> FindByCities(string cities)
        {
            return _citiesRepo.GetByCities(cities);
        }*/


        public bool Edit(int id, CityView editCity)
        {
            City orginalCity = FindById(id);
            if (orginalCity != null)
            {  
                orginalCity.Name = editCity.Name;
            }
            return _citiesRepo.Update(orginalCity);
            // return _citiesRepo.Update(city);
        }

        public bool Remove(int id)
        {
            City cityToDelete = _citiesRepo.GetById(id);
            bool success = _citiesRepo.Delete(cityToDelete);

            return success;

        }

        public List<City>? GetAllCitiesByCountryId(int id)
        {

            List<City>? cityList = _citiesRepo.GetAllCitiesByCountryId(id);
            return cityList;
        }



    }
}
