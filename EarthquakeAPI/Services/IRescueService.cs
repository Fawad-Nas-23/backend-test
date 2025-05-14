using EarthquakeAPI.Models;

namespace EarthquakeAPI.Services
{
    public interface IRescueService
    {
        void AddPerson(Person person);
        void UpdateLocation(string firstName, string lastName, Location newLocation);
        List<Person> GetAllSurvivors();
        double GetSurvivorPercentage();
        List<Person> SearchByLastName(string lastName);
        List<Person> GetAllPeople();
    }
}
