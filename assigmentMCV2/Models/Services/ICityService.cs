using assigmentMVC2.Models.ViewModels;
using System;

namespace assigmentMVC2.Models.Services
{
    public interface ICityService
    {
        City Create(CityView editCity);
        List<City> GetAll();
        //List<City> FindByCities(string cities);
        City FindById(int id);
        bool Edit(int id, CityView editCity);
        bool Remove(int id);

        List<City>? GetAllCitiesByCountryId(int id);
    }
}
