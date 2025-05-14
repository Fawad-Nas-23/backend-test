using EarthquakeAPI.Models;

namespace EarthquakeAPI.Repository
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);
        List<Person> GetAllPeople();
        List<Person> GetAllSurvivors();
        List<Person> SearchByLastName(string lastname);
        void UpdateLocation(string firstName, string lastName, Location newLocation);

        Person GetPerson(string firstName, string lastName);
    }
}
