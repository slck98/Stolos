using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("[controller]")] // wordt .../GasCard
    public class GasCardController : Controller
    {
        private readonly ILogger<GasCardController> logger;

        private static List<DriversLicense> _licenses = new List<DriversLicense> { DriversLicense.B, DriversLicense.C1 };

        private static Driver _driver = new Driver(2, "Doe", "John", new DateTime(1985 - 12 - 31), "85.12.31-123.12", _licenses);
        
        private static List<FuelType> _fuelTypes = new List<FuelType> { FuelType.Benzine, FuelType.Diesel };

        private readonly List<GasCard> _gascard = new()
        {
            new GasCard("12345678900000000001", new DateTime(2023-12-31), 1234, false, _fuelTypes, _driver)
        };

        public GasCardController(ILogger<GasCardController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "GetGasCards")]
        public List<GasCard> Get()
        {
            return _gascard;
        }
    }
}
