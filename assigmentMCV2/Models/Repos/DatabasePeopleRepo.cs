using assigmentMVC2.Data;

namespace assigmentMVC2.Models.Repos
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        public PeopleDbContext _peopleDbContext;

        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Person Create(Person person)
         {
            //person.Id = ++idCounter;
            //peopleList.Add(person)
            _peopleDbContext.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }

        public Person Create(string name, string phoneNumber, string city)
        {
            Person person = new Person(name, phoneNumber, city);
            //person.Id = ++idCounter;            
            //peopleList.Add(person);
            _peopleDbContext.Add(person);
            _peopleDbContext.SaveChanges();
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
            peopleList = _peopleDbContext.People.ToList();
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
            return _peopleDbContext.People.Where(p => p.City.Contains(cities)).ToList();
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
            return _peopleDbContext.People.SingleOrDefault(p => p.Id == id);
        }

        public bool Update(Person person)
        {
            Person orginalPerson = GetById(person.Id);
            if (orginalPerson != null)
            {
                orginalPerson.PersonName = person.PersonName;
                orginalPerson.City = person.City;
                _peopleDbContext.Update(orginalPerson);
                _peopleDbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(Person person)
        {
            //return peopleList.Remove(person);
            if (person != null)
            {
                _peopleDbContext.Remove(person);
                _peopleDbContext.SaveChanges();
                return true;
            }          

            return false;
        }
    }
}
