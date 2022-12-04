using assigmentMVC2.Models.ViewModels;
using System;

namespace assigmentMVC2.Models.Services
{
    public interface IPeopleService
    {
        Person Create(PersonView createPerson);
        List<Person> GetAll();
        List<Person> FindByCities(string cities);
        Person FindById(int id);
        bool Edit(int id, PersonView editPerson);
        bool Remove(int id);
        /*Person Add(PersonView createPerson);*/
        
        Person LastAdded();
    }
}
