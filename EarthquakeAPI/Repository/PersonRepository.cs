using EarthquakeAPI.Models;

namespace EarthquakeAPI.Repository
{
    public class PersonRepository
    {
        private readonly List<Person> _people = new();

        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

        public List<Person> GetAllPeople()
        {
            return _people;
        }

        public void UpdateLocation(string firstName, string lastName, Location newLocation)
        {
            var person = _people.FirstOrDefault(p => p.firstName == firstName && p.lastName == lastName);

            if (person == null) return;

            person.location = newLocation;
        }
    }

}
