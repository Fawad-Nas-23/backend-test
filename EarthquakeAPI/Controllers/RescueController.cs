using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EarthquakeAPI.Models;
using EarthquakeAPI.Repository;
using EarthquakeAPI.Services;

namespace EarthquakeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RescueController : Controller
    {
        private readonly IRescueService _rescueService;
        public RescueController(IRescueService rescueService)
        {
            _rescueService = rescueService;
        }

        /// <summary>
        /// Get a list of all people in the registry (alive or dead).
        /// </summary>
        /// <returns>List of all registered people.</returns>
        [HttpGet("getallpeople")]
        public IActionResult GetAllPeople()
        {
            var people = _rescueService.GetAllPeople();
            return Ok(people);
        }

        /// <summary>
        /// Get a list of all current known survivors (people marked as alive).
        /// </summary>
        /// <returns> List of all survivors and their locations.</returns>
        [HttpGet("getallsurvivors")]
        public IActionResult GetAllSurvivors()
        {
            var survivors = _rescueService.GetAllSurvivors();
            return Ok(survivors);
        }

        /// <summary>
        /// Add a new person to the registry (alive or dead).
        /// </summary>
        /// <param name="person">The person object to add.</param>
        /// <returns>Returns 200 OK if added, 400 Bad Request if input is invalid</returns>
        [HttpPost("addperson")]
        public IActionResult AddPerson(Person person)
        {
            if (person == null)
            {
                return BadRequest("Person cannot be null");
            }
            else
            {
                
                _rescueService.AddPerson(person);
                return Ok("Person added");
            }
                
        }

        /// <summary>
        /// Update a survivor's last known location.
        /// </summary>
        /// <param name="firstName">First name of the person.</param>
        /// <param name="lastName">Last name of the person.</param>
        /// <param name="newLocation">New location (latitude, longitude).</param>
        /// <returns>Returns 200 OK if updated, or 400 Bad Request if validation fails.</returns>
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
                catch (ArgumentException ex)
                {
                    return NotFound(ex.Message); 
                }
            }
        }



        /// <summary>
        /// Get the percentage of survivors in the total population.
        /// </summary>
        /// <returns>Survivor percentage as double.</returns>
        [HttpGet("survivorpercentage")]
        public double GetSurvivorPercentage()
        {
            double percentage = _rescueService.GetSurvivorPercentage();
            return percentage;
        }

        /// <summary>
        /// Search for people by last name (both alive and deceased).
        /// </summary>
        /// <param name="lastName">Last name to search for.</param>
        /// <returns>List of matched people.</returns>
        [HttpGet("searchbylastname")]
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
