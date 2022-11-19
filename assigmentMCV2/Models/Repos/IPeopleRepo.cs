namespace assigmentMVC2.Models.Repos
{
    public interface IPeopleRepo
    {
        //Crud

        // C

        Person Create(Person person);
        Person Create(string name, string phoneNumber, string city);
        // R
        List<Person> GetAll();
        List<Person> GetByCities(string cities);
        Person GetById(int id);

        // U
        bool Update(Person person);

        // D
        bool Delete(Person person);
    }
}
