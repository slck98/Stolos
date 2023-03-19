using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("[controller]")] // wordt .../Driver

    public class DriverController : Controller
    {
        private readonly ILogger<DriverController> logger;

        private static List<DriversLicense> _licenses = new List<DriversLicense> { DriversLicense.B, DriversLicense.C1};
        

        private readonly List<Driver> _driver = new()
        {
            new Driver(2, "Doe", "John", "85.12.31-123.40", _licenses)
        };

        public DriverController(ILogger<DriverController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "GetDrivers")]
        public List<Driver> Get()
        {
            return _driver;
        }
    }
}
