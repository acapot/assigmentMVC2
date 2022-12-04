namespace assigmentMVC2.Models.Repos
{
    public interface ICountryRepo
    {
        //Crud

        // C

        Country Create(Country country);
      
        // R
        List<Country> GetAll();
       
        Country GetById(int id);

        // U
        bool Update(Country country);

        // D
        bool Delete(Country country);
    }
}
