using EarthquakeAPI.Models;
using EarthquakeAPI.Repository;

namespace EarthquakeAPI.Services
{
    public class RescueService : IRescueService
    {
        private readonly IPersonRepository _repo;

        public RescueService(IPersonRepository repo)
        {
            _repo = repo;
        }

        public List<Person> GetAllPeople()
        {
            return _repo.GetAllPeople();
        }

        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentException("Person cannot be null");
            }
            
            _repo.AddPerson(person);
        }

        public List<Person> GetAllSurvivors()
        {
            return _repo.GetAllSurvivors();
        }

        public double GetSurvivorPercentage()
        {
            var allPeople = _repo.GetAllPeople();
            if (allPeople.Count == 0)
            {
                return 0.0;

            }
            int totalSurvivors = allPeople.Count(p => p.isAlive);
            return (double)totalSurvivors / allPeople.Count * 100;
        }

        public List<Person> SearchByLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Last name cannot be null or empty");
            }

            return _repo.SearchByLastName(lastName);
        }

        public void UpdateLocation(string firstName, string lastName, Location newLocation)
        {
            var person = _repo.GetPerson(firstName, lastName);

            if (person == null)
            {
                throw new ArgumentException("Person not found.");
            }

            if (!person.isAlive)
            {
                throw new ArgumentException("Person is dead.");
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
