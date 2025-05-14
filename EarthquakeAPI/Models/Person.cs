namespace EarthquakeAPI.Models
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public bool isAlive { get; set; }
        public Location location { get; set; }
    }
}
