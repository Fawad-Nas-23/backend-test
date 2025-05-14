using EarthquakeAPI.Models;

namespace EarthquakeAPI.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly List<Person> _people = new();

        public PersonRepository()
        {
            AddPerson(new Person { firstName = "anna", lastName = "jensen", age = 30, gender = "female", isAlive = true, location = new Location { latitude = 12.0, longitude = 45.0 } });
            AddPerson(new Person { firstName = "bo", lastName = "jensen", age = 45, gender = "male", isAlive = false, location = new Location { latitude = 13.0, longitude = 46.0 } });
            AddPerson(new Person { firstName = "camilla", lastName = "larsen", age = 22, gender = "female", isAlive = true, location = new Location { latitude = 10.5, longitude = 40.0 } });
            AddPerson(new Person { firstName = "david", lastName = "larsen", age = 50, gender = "male", isAlive = false, location = new Location { latitude = 11.0, longitude = 41.0 } });
            AddPerson(new Person { firstName = "eva", lastName = "andersen", age = 28, gender = "female", isAlive = true, location = new Location { latitude = -15.0, longitude = 20.0 } });
            AddPerson(new Person { firstName = "frederik", lastName = "andersen", age = 60, gender = "male", isAlive = true, location = new Location { latitude = -16.5, longitude = 22.0 } });
            AddPerson(new Person { firstName = "gitte", lastName = "nielsen", age = 33, gender = "female", isAlive = false, location = new Location { latitude = 5.0, longitude = 50.0 } });
            AddPerson(new Person { firstName = "hans", lastName = "nielsen", age = 36, gender = "male", isAlive = true, location = new Location { latitude = 6.0, longitude = 51.0 } });
            AddPerson(new Person { firstName = "ida", lastName = "mortensen", age = 40, gender = "female", isAlive = true, location = new Location { latitude = -8.0, longitude = 25.0 } });
            AddPerson(new Person { firstName = "jakob", lastName = "mortensen", age = 42, gender = "male", isAlive = false, location = new Location { latitude = -9.0, longitude = 26.0 } });
            AddPerson(new Person { firstName = "karen", lastName = "thomsen", age = 37, gender = "female", isAlive = true, location = new Location { latitude = 14.0, longitude = 44.0 } });
            AddPerson(new Person { firstName = "lars", lastName = "thomsen", age = 39, gender = "male", isAlive = false, location = new Location { latitude = 15.0, longitude = 45.0 } });
            AddPerson(new Person { firstName = "mette", lastName = "olsen", age = 27, gender = "female", isAlive = true, location = new Location { latitude = -2.5, longitude = 18.0 } });
            AddPerson(new Person { firstName = "niels", lastName = "olsen", age = 35, gender = "male", isAlive = false, location = new Location { latitude = -3.5, longitude = 19.0 } });
        }

        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

        public List<Person> GetAllPeople()
        {
            return _people;
        }

        public List<Person> GetAllSurvivors()
        {
            return _people.Where(p => p.isAlive).ToList();
        }

        public List<Person> SearchByLastName(string lastname)
        {
            return _people.Where(p => p.lastName.Equals(lastname)).ToList();
        }

        public void UpdateLocation(string firstName, string lastName, Location newLocation)
        {
            var person = _people.FirstOrDefault(p => p.firstName == firstName && p.lastName == lastName);

            if (person == null)
            {
                throw new ArgumentException("Person not found.");
            } 

            person.location = newLocation;
        }

        public Person GetPerson(string firstName, string lastName)
        {
            return _people.FirstOrDefault(p => p.firstName == firstName && p.lastName == lastName);
        }
    }

}
