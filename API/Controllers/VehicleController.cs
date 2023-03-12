using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("[controller]")] // wordt .../vehicle
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> logger;

        private readonly List<Vehicle> _vehicles = new()
        {
            new Vehicle() 
            { 
                VinNumber = "0123456789ABCDEFF",
                LicensePlate = "1-ABC-124",
                Categorie = (Vehicle.VehicleType)1,
                Fuel = (Vehicle.FuelType)1
            },
        };

        public VehicleController(ILogger<VehicleController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "GetVehicles")]
        public List<Vehicle> Get()
        {
            return _vehicles;
        }
    }
}
