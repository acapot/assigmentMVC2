using assigmentMVC2.Models.ViewModels;

namespace assigmentMVC2.Models.Repos
{
    public interface ICityRepo
    {
        //Crud

        // C

        City Create(string name);
        City Create(City city);

        // R
        List<City> GetAll();
       
        City GetById(int id);

        // U
        bool Update(City city);

        // D
        bool Delete(City city);
        List<City>? GetAllCitiesByCountryId(int id);
    }
}
