using assigmentMVC2.Models.ViewModels;
using System;

namespace assigmentMVC2.Models.Services
{
    public interface IPeopleService
    {
        Person Create(CreatePersonViewModel createPerson);
        List<Person> GetAll();
        List<Person> FindByCities(string cities);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel editPerson);
        bool Remove(int id);
        Person Add(CreatePersonViewModel createPerson);
        Person LastAdded();
    }
}
