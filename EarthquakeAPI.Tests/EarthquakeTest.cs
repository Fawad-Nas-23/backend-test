using Microsoft.AspNetCore.Components.Routing;
using System;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using EarthquakeAPI.Models;
using EarthquakeAPI.Repository;
namespace EarthquakeAPI.Tests;

[TestClass]
public sealed class EarthquakeTest
{
    [TestMethod]
    public void TestAddPerson()
    {
        var repository = new PersonRepository();
        var person = new Person
        {
            firstName = "John",
            lastName = "Doe",
            age = 30,
            gender = "male",
            isAlive = true,
            location = new EarthquakeAPI.Models.Location { latitude = 10.0, longitude = 20.0 }
        };

        repository.AddPerson(person);
        var result = repository.GetAllPeople().FirstOrDefault();
        Assert.AreEqual("John", result.firstName);
    }

    [TestMethod]
    public void UpdateLocation()
    {
        var repo = new PersonRepository();
        var person = new Person
        {
            firstName = "Anna",
            lastName = "Jensen",
            age = 30,
            gender = "female",
            isAlive = true,
            location = new EarthquakeAPI.Models.Location { latitude = 15.0, longitude = 45.0 } // Northern hemisphere
        };

        repo.AddPerson(person);

        var newLocation = new EarthquakeAPI.Models.Location { latitude = 20.0, longitude = 50.0 }; // Still northern

        repo.UpdateLocation(person.firstName, person.lastName, newLocation);

        var updated = repo.GetAllPeople().First(p => p.firstName == "Anna" && p.lastName == "Jensen");
        Assert.AreEqual(20.0, updated.location.latitude);
        Assert.AreEqual(50.0, updated.location.longitude);

    }

}
