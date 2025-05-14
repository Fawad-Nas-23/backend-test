using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EarthquakeAPI.Models;
using EarthquakeAPI.Repository;
using EarthquakeAPI.Services;

namespace EarthquakeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EarthquakeController : Controller
    {
        private readonly IRescueService _rescueService;
        public EarthquakeController(IRescueService rescueService)
        {
            _rescueService = rescueService;
        }

        /// <summary>
        /// Get a list of all people in the registry.
        /// </summary>
        [HttpGet("getallpeople")]
        public IActionResult GetAllPeople()
        {
            var people = _rescueService.GetAllPeople();
            return Ok(people);
        }

        /// <summary>
        /// Add a new person to the survivor registry.
        /// </summary>
        [HttpPost("add")]
        public IActionResult AddPerson(Person person)
        {
            if (person == null)
            {
                return BadRequest("Person cannot be null");
            }
            else
            {
                try
                {
                    _rescueService.AddPerson(person);
                    return Ok("Person added");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
                
        }

        /// <summary>
        /// Update the location of a survivor.
        /// </summary>
        [HttpPut("updatelocation")]
        public IActionResult UpdateLocation(string firstName, string lastName, Location newLocation)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || newLocation == null)
            {
                return BadRequest("Invalid input");
            }
            else
            {
                try
                {
                    _rescueService.UpdateLocation(firstName, lastName, newLocation);
                    return Ok("Location updated");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }

        /// <summary>
        /// Get a list of all survivors.
        /// </summary>
        [HttpGet("getallsurvivors")]
        public IActionResult GetAllSurvivors()
        {
            var survivors = _rescueService.GetAllSurvivors();
            return Ok(survivors);
        }

        /// <summary>
        /// Get the percentage of survivors.
        /// </summary>
        [HttpGet("survivorpercentage")]
        public double GetSurvivorPercentage()
        {
            double percentage = _rescueService.GetSurvivorPercentage();
            return percentage;
        }

        /// <summary>
        /// Search for people by last name.
        /// </summary>
        [HttpGet("search")]
        public IActionResult SearchByLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return BadRequest("Last name is required.");
            }

            var results = _rescueService.SearchByLastName(lastName);
            return Ok(results);
        }

    }

}
