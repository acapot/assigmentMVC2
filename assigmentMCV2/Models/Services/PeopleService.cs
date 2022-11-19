using assigmentMVC2.Models.Repos;
using assigmentMVC2.Models.ViewModels;

namespace assigmentMVC2.Models.Services
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }
        public Person Create(CreatePersonViewModel createPerson)
        {
            if (string.IsNullOrWhiteSpace(createPerson.PersonName) || string.IsNullOrWhiteSpace(createPerson.City) || string.IsNullOrWhiteSpace(createPerson.PhoneNumber))
            { throw new ArgumentException("PersonName, City allowed whitespace"); }

            Person person = new Person() { PersonName = createPerson.PersonName, City = createPerson.City, PhoneNumber = createPerson.PhoneNumber};
            person = _peopleRepo.Create(person);
            return person;
        }

        public Person FindById(int id)
        {
            return _peopleRepo.GetById(id);
        }
        public List<Person> GetAll()
        {
            return _peopleRepo.GetAll();
        }
        public List<Person> FindByCities(string cities)
        {
            return _peopleRepo.GetByCities(cities);
        }


        public bool Edit(int id, CreatePersonViewModel editPerson)
        {
            Person orginalPerson = FindById(id);
            if (orginalPerson != null)
            {
               
                orginalPerson.PersonName = editPerson.PersonName;
                orginalPerson.PhoneNumber = editPerson.PhoneNumber;
                orginalPerson.City = editPerson.City;
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
        public Person? LastAdded()
        {
            List<Person> people = _peopleRepo.GetAll();
            if (people.Count < 1)// try with == 0
            {
                return null;
            }
            return people.Last();
        }

        public Person Add(CreatePersonViewModel createPerson)
        {
            Person person = _peopleRepo.Create(createPerson.PersonName, createPerson.PhoneNumber, createPerson.City);
            if (string.IsNullOrWhiteSpace(createPerson.PersonName)
                || string.IsNullOrWhiteSpace(createPerson.PhoneNumber)
                || string.IsNullOrWhiteSpace(createPerson.City))
            {
                throw new ArgumentException("Name,PhoneNumber or City, not be consist of backspace(s)/whitespace(s)");
            }

            return person;
        }

    }
}
