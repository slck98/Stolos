using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController] // voor DI
[Route("[controller]")] // wordt .../vehicle
public class VehicleController : ControllerBase
{
    private readonly ILogger<VehicleController> logger;

    private readonly List<Vehicle> _vehicles = new()
    {
        new Vehicle("0123456789ABCDEFF", "1-ABC-123", "VW Polo", (VehicleType)1, (FuelType)1)
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
