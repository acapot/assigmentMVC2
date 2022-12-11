using assigmentMVC2.Models.Repos;
using assigmentMVC2.Models.ViewModels;
using System.Xml.Linq;

namespace assigmentMVC2.Models.Services
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        ICityRepo _cityRepo;
        public PeopleService(IPeopleRepo peopleRepo, ICityRepo cityRepo)
        {
            _peopleRepo = peopleRepo;
            _cityRepo = cityRepo;   
        }
        public PersonView Create(CreatePersonView createPerson)
        {
            PersonView pv = new PersonView();

            if (string.IsNullOrWhiteSpace(createPerson.PersonName)  || string.IsNullOrWhiteSpace(createPerson.PhoneNumber))
            { throw new ArgumentException("PersonName, City not allowed whitespace"); }

            Person person = new Person() { PersonName = createPerson.PersonName, 
                City = _cityRepo.GetById(createPerson.CityId), 
                PhoneNumber = createPerson.PhoneNumber};
            person = _peopleRepo.Create(person);


            pv.Id = person.Id;
            pv.PersonName = person.PersonName;
            pv.PhoneNumber = person.PhoneNumber;
            pv.City = person.City?.Name!;
            pv.Country = person.City?.Country?.Name!;            

            return pv;
        }

        public PersonView FindById(int id)
        {
            var p = _peopleRepo.GetById(id);

            if (p == null)
            {
                return null;
            }

            return new PersonView
            {
                Id = p.Id,
                PersonName = p.PersonName,
                PhoneNumber = p.PhoneNumber,
                City = p.City?.Name!,
                Country = p.City?.Country?.Name!,
                CityId = p.CityId
            };
        }
        public List<PersonView> GetAll()
        {
            return _peopleRepo.GetAll().Select(p => new PersonView
            {
                Id = p.Id,
                PersonName = p.PersonName,
                PhoneNumber = p.PhoneNumber,
                City = p.City?.Name!,
                Country = p.City?.Country?.Name!
            }).ToList();
            //return _peopleRepo.GetAll();
        }
        public List<Person> FindByCities(string cities)
        {
            return _peopleRepo.GetByCities(cities);
        }


        public bool Edit(int id, CreatePersonView editPerson)
        {
            Person orginalPerson = _peopleRepo.GetById(id);
            if (orginalPerson != null)
            {               
                orginalPerson.PersonName = editPerson.PersonName;
                orginalPerson.PhoneNumber = editPerson.PhoneNumber;
                orginalPerson.City = _cityRepo.GetById(editPerson.CityId);
            }
            return _peopleRepo.Update(orginalPerson);
            // return _peopleRepo.Update(person);
        }

        public bool Remove(int id)
        {
            Person personToDelete = _peopleRepo.GetById(id);
            bool success = _peopleRepo.Delete(personToDelete);

            return success;

        }
       /* public Person? LastAdded()
        {
            List<Person> people = _peopleRepo.GetAll();
            if (people.Count < 1)// try with == 0
            {
                return null;
            }
            return people.Last();
        }*/

        

        /*public Person Add(PersonView createPerson)
        {
            Person person = _peopleRepo.Create(createPerson.PersonName, createPerson.PhoneNumber, createPerson.City);
            if (string.IsNullOrWhiteSpace(createPerson.PersonName)
                || string.IsNullOrWhiteSpace(createPerson.PhoneNumber))
            {
                throw new ArgumentException("Name or PhoneNumber, not be consist of backspace(s)/whitespace(s)");
            }

            return person;
        }*/

    }
}
