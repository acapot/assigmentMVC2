using assigmentMVC2.Data;
using Microsoft.EntityFrameworkCore;

namespace assigmentMVC2.Models.Repos
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        public AppDbContext _appDbContext;

        public DatabasePeopleRepo(AppDbContext peopleDbContext)
        {
            _appDbContext = peopleDbContext;
        }

        public Person Create(Person person)
         {
            //person.Id = ++idCounter;
            //peopleList.Add(person)
            _appDbContext.Add(person);
            _appDbContext.SaveChanges();
            return person;
        }

        public Person Create(string name, string phoneNumber, City city)
        {
            Person person = new Person(name, phoneNumber, city);
            //person.Id = ++idCounter;            
            //peopleList.Add(person);
            _appDbContext.Add(person);
            _appDbContext.SaveChanges();
            return person;
        }

        public List<Person> GetAll()
        {
            /* if (idCounter == 0)
             {
                 peopleList.Add(new Person() { Id = ++idCounter, PersonName = "Ken", City = "Stockholm", PhoneNumber = "70065982" });
                 peopleList.Add(new Person() { Id = ++idCounter, PersonName = "Nino", City = "Stockholm", PhoneNumber = "80068255" });
                 peopleList.Add(new Person() { Id = ++idCounter, PersonName = "Yino", City = "Stockholm", PhoneNumber = "90065888" });

             }*/
            List<Person> peopleList = new List<Person>();
            peopleList = _appDbContext.People!
                .Include(p => p.City)
                .ThenInclude(c => c.Country)
                .ToList();
            return peopleList;
        }

        public List<Person> GetByCities(string cities)
        {
            //List<Person> personCities = new List<Person>();
            /*List<Person> personCities = _peopleDbContext.People.Where(p => p.);
            foreach (Person aPerson in peopleList)
            {
                if (aPerson.City == cities)
                {
                    personCities.Add(aPerson);
                }
            }*/
            return _appDbContext.People.Where(p => p.City.Name.Contains(cities)).ToList();
        }
        public Person GetById(int id)
        {
            //Person person = null;
            /*Person person = _peopleDbContext.People.Where(p => p.Id == id);
            foreach (Person aPerson in peopleList)
            {
                if (aPerson.Id == id)
                {
                    person = aPerson;
                    break;
                }
            }*/
            return _appDbContext.People!
                .Include(p => p.City)
                .ThenInclude(c => c!.Country)
                .SingleOrDefault(p => p.Id == id);
        }

        public bool Update(Person person)
        {
            /*Person originalPerson = GetById(person.Id);
            if (originalPerson != null)
            {
                originalPerson.PersonName = person.PersonName;
                originalPerson.CityId = person.CityId;
                _appDbContext.Update(originalPerson);
                _appDbContext.SaveChanges();
                return true;
            }*/

            var result = _appDbContext.People!.Update(person);

            return _appDbContext.SaveChanges() > 0;
        }

        public bool Delete(Person person)
        {
            //return peopleList.Remove(person);
            if (person != null)
            {
                _appDbContext.Remove(person);
                _appDbContext.SaveChanges();
                return true;
            }          

            return false;
        }
    }
}
