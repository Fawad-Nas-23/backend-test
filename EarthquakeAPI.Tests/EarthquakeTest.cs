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
}
