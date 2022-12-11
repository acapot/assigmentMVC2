using assigmentMVC2.Models.ViewModels;
using System;

namespace assigmentMVC2.Models.Services
{
    public interface IPeopleService
    {
        PersonView Create(CreatePersonView createPerson);
        List<PersonView> GetAll();
        List<Person> FindByCities(string cities);
        PersonView FindById(int id);
        bool Edit(int id, CreatePersonView editPerson);
        bool Remove(int id);
        /*Person Add(PersonView createPerson);*/
        
        //Person LastAdded();
    }
}
