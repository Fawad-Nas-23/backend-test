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
    public void TestUpdateLocationInSameHemisphere()
    {
        var repo = new PersonRepository();
        var person = new Person
        {
            firstName = "Anna",
            lastName = "Jensen",
            age = 30,
            gender = "female",
            isAlive = true,
            location = new EarthquakeAPI.Models.Location { latitude = 15.0, longitude = 45.0 }
        };

        repo.AddPerson(person);

        var newLocation = new EarthquakeAPI.Models.Location { latitude = 20.0, longitude = 50.0 };

        repo.UpdateLocation(person.firstName, person.lastName, newLocation);

        var updated = repo.GetAllPeople().First(p => p.firstName == "Anna" && p.lastName == "Jensen");
        Assert.AreEqual(20.0, updated.location.latitude);
        Assert.AreEqual(50.0, updated.location.longitude);

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestUpdateLocationInDifferentHemisphere()
    {
        var repo = new PersonRepository();
        var person = new Person
        {
            firstName = "Bjørn",
            lastName = "Haraldsen",
            age = 20,
            gender = "male",
            isAlive = true,
            location = new EarthquakeAPI.Models.Location { latitude = 15.0, longitude = 45.0 }
        };

        repo.AddPerson(person);

        var newLocation = new EarthquakeAPI.Models.Location { latitude = -20.0, longitude = -50.0 };

        repo.UpdateLocation(person.firstName, person.lastName, newLocation);
    }

    [TestMethod]
    public void TestGetAllSurvivorsWithLocations()
    {
        var repo = new PersonRepository();

        var alivePerson = new Person
        {
            firstName = "Anna",
            lastName = "Larsen",
            age = 28,
            gender = "female",
            isAlive = true,
            location = new EarthquakeAPI.Models.Location { latitude = 10.0, longitude = 20.0 }
        };

        var deceasedPerson = new Person
        {
            firstName = "Bo",
            lastName = "Larsen",
            age = 50,
            gender = "male",
            isAlive = false,
            location = new EarthquakeAPI.Models.Location { latitude = 15.0, longitude = 25.0 }
        };

        repo.AddPerson(alivePerson);
        repo.AddPerson(deceasedPerson);

        var survivors = repo.GetAllSurvivors();

        Assert.AreEqual(1, survivors.Count);
        Assert.AreEqual("Anna", survivors[0].firstName);
        Assert.AreEqual(10.0, survivors[0].location.latitude);
        Assert.AreEqual(20.0, survivors[0].location.longitude);
    }

    //[TestMethod]
    //public void TestGetSurvivorPercantage()
    //{
    //    var repo = new PersonRepository();

    //    var person1 = new Person
    //    {
    //        firstName = "Anna",
    //        lastName = "Larsen",
    //        isAlive = true
    //    };

    //    var person2 = new Person
    //    {
    //        firstName = "Bo",
    //        lastName = "Larsen",
    //        isAlive = false
    //    };

    //    repo.AddPerson(person1);
    //    repo.AddPerson(person2);


    //    //double percentage = repo.GetSurvivorPercentage();

    //    Assert.AreEqual(50, percentage);
    //}

    [TestMethod]
    public void TestSearchByLasName()
    {
        var repo = new PersonRepository();
        var person1 = new Person
        {
            firstName = "Anna",
            lastName = "Larsen",
            isAlive = true
        };
        var person2 = new Person
        {
            firstName = "Bo",
            lastName = "Larsen",
            isAlive = false
        };
        repo.AddPerson(person1);
        repo.AddPerson(person2);

        var result = repo.SearchByLastName("Larsen");
        Assert.AreEqual(2, result.Count);

    }


}