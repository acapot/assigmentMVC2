using assigmentMVC2.Data;

namespace assigmentMVC2.Models.Repos
{
    //public class PeopleRepo : IPeopleRepo
    public class PeopleRepo
    {
        static int idCounter = 0;
        static List<Person> peopleList = new List<Person>();

        public Person Create(Person person)
        {
            person.Id = ++idCounter;
            peopleList.Add(person);
            return person;
        }

        public Person Create(string name, string phoneNumber, City city)
        {
            Person person = new Person(name, phoneNumber, city);
            person.Id = ++idCounter;
            peopleList.Add(person);
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

            return peopleList;
        }
/*
        public List<Person> GetByCities(string cities)
        {
            List<Person> personCities = new List<Person>();
            foreach (Person aPerson in peopleList)
            {
                if (aPerson.City == cities)
                {
                    personCities.Add(aPerson);
                }
            }
            return personCities;
        }*/
        public Person GetById(int id)
        {
            Person person = null;
            foreach (Person aPerson in peopleList)
            {
                if (aPerson.Id == id)
                {
                    person = aPerson;
                    break;
                }
            }
            return person;
        }

        public bool Update(Person person)
        {
            Person orginalPerson = GetById(person.Id);
            if (orginalPerson != null)
            {
                orginalPerson.PersonName = person.PersonName;
                orginalPerson.CityId = person.CityId;
                return true;
            }

            return false;
        }

        public bool Delete(Person person)
        {
            return peopleList.Remove(person);
        }
    }
}
