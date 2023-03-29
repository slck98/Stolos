using BusinessLayer.DTO;
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
    public List<VehicleInfo> Get()
    {
        //return _vehicleManager.GetAllVehicles();
        return _vehicleManager.GetAllVehicleInfos();
    }

    [HttpGet("{vin}", Name = "GetVehicleByVin")]
    public VehicleInfo Get(string vin)
    {
        return _vehicleManager.GetVehicleByVIN(vin);
    }


    [HttpPost, Route("addVehicle")]
    public OkResult Add(VehicleInfo vehicle)
    {
        _vehicleManager.AddVehicle(vehicle);
        return Ok();
    }
}
