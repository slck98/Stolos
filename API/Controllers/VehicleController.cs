using BusinessLayer.Managers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController] // voor DI
[Route("[controller]")] // wordt .../vehicle
public class VehicleController : ControllerBase
{
    private readonly ILogger<VehicleController> logger;
    private VehicleManager _vehicleManager;

    public VehicleController(ILogger<VehicleController> logger, IConfiguration iConfig)
    {
        this.logger = logger;

        _vehicleManager = new VehicleManager(new VehicleRepository(iConfig.GetValue<string>("ConnectionStrings:stolos")));
    }

    [HttpGet(Name = "GetVehicles")]
    public List<Vehicle> Get()
    {
        return _vehicleManager.GetAllVehicles();
    }

    [HttpGet("{vin}", Name = "GetVehicleByVin")]
    public Vehicle Get(string vin)
    {
        return _vehicleManager.GetVehicleByVIN(vin);
    }
}
