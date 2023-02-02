using assigmentMVC2.Models.ViewModels;
using System;

namespace assigmentMVC2.Models.Services
{
    public interface ICountryService
    {
        CountryView Create(CreateCountryView country);
        List<CountryView> GetAll();
        bool Remove(int id);
        public CountryView? FindById(int id);
        public CountryView Edit(int id);
        public bool Update(int id, CreateCountryView countryView);
    }
   
}
