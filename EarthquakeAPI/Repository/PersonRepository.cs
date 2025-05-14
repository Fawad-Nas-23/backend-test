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

        public List<Person> GetAllSurvivors()
        {
            return _people.Where(p => p.isAlive).ToList();
        }

        public void UpdateLocation(string firstName, string lastName, Location newLocation)
        {
            var person = _people.FirstOrDefault(p => p.firstName == firstName && p.lastName == lastName);

            if (person == null)
            {
                throw new ArgumentException("Person not found.");
            }

            if (!person.isAlive)
            {
                throw new InvalidOperationException("Cannot update location of a deceased person.");
            }

            bool sameHemisphere = (person.location.latitude >= 0 && newLocation.latitude >= 0) || (person.location.latitude < 0 && newLocation.latitude < 0);

            if (!sameHemisphere)
            {
                throw new ArgumentException("Cannot cross hemispheres.");

            }

            person.location = newLocation;
        }

    }

}
