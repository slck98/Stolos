using API.Exceptions;
using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Managers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace API.Controllers;

[ApiController] // voor DI
[Route("[controller]")] // wordt .../vehicle
public class VehicleController : ControllerBase
{
    private readonly ILogger<VehicleController> logger;
    private IConfiguration iConfig;
    private VehicleManager _vehicleManager;

    public VehicleController(ILogger<VehicleController> logger, IConfiguration config)
    {
        this.logger = logger;
        this.iConfig = config;
        _vehicleManager = new VehicleManager(new VehicleRepository(iConfig.GetValue<string>("ConnectionStrings:stolos")));
    }

    [HttpGet(Name = "GetVehicles")]
    public ActionResult<List<VehicleInfo>> Get()
    {
        try
        {
            List<VehicleInfo> vis = _vehicleManager.GetAllVehicleInfos();
            if (vis == null) return NotFound();
            return vis;
        }
        catch (Exception ex)
        {
            throw new APIException("VehicleController GetAllVehiclesInfos", ex);
        }
    }

    [HttpGet("{vin}", Name = "GetVehicleByVin")]
    public ActionResult<VehicleInfo> Get(string vin)
    {
        try
        {
            VehicleInfo vi = _vehicleManager.GetVehicleByVIN(vin);
            if (vi == null) return NotFound();
            return vi;
        }
        catch (Exception ex)
        {
            throw new APIException("VehicleController GetVehicleByVin", ex);
        }
    }

    [HttpPost(Name = "addVehicle")]
    public OkResult Add(string vin, string brandModel, string licensePlate, FuelType fuelType, VehicleType vehicleType, string? color, int? doors, int? driverId, string fname, string lname, string address, DateTime birthDate, string natRegNum, List<DriversLicense> driversLicenses)
    {
        try
        {
            if (string.IsNullOrEmpty(vin)) throw new Exception();
            Vehicle v = DomainFactory.CreateVehicle(vin, brandModel, licensePlate, vehicleType, fuelType, color, doors);
            Driver? d = null;
            if (driverId != null)
            {
                d = DomainFactory.CreateDriver(driverId, lname, fname, natRegNum, driversLicenses, birthDate, address);
            }
            VehicleInfo vi = new(v, d);
            _vehicleManager.AddVehicle(vi);
            return Ok();
        }
        catch (Exception ex)
        {
            throw new APIException("VehicleController AddVehicle", ex);
        }
    }

    [HttpPut (Name = "updateVehicles")]
    public OkResult Put(string vin, string brandModel, string licensePlate, FuelType fuelType, VehicleType vehicleType, string? color, int? doors, int? driverId, string fname, string lname, string address, DateTime birthDate, string natRegNum, List<DriversLicense> driversLicenses)
    {
        try
        {
            if (string.IsNullOrEmpty(vin)) throw new Exception();
            Vehicle v = DomainFactory.CreateVehicle(vin, brandModel, licensePlate, vehicleType, fuelType, color, doors);
            Driver? d = null;
            if (driverId != null)
            {
                d = DomainFactory.CreateDriver(driverId, lname, fname, natRegNum, driversLicenses, birthDate, address);
            }
            VehicleInfo vi = new(v, d);
            _vehicleManager.AddVehicle(vi);
            return Ok();
        }
        catch (Exception ex)
        {
            throw new APIException("VehicleController updateVehicle", ex);
        }
    }

}
