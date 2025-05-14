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

    }

}
