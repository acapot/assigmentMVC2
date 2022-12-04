using assigmentMVC2.Models.ViewModels;
using System;

namespace assigmentMVC2.Models.Services
{
    public interface ICountryService
    {
        Country Create(CountryView country);
        List<Country> GetAll();
        //List<Country> FindByCities(string cities);
        Country FindById(int id);
        bool Edit(int id, CountryView editCountry);
        bool Remove(int id);
    }
   
}
