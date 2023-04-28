using API.Exceptions;
using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Exceptions;
using BusinessLayer.Managers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
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
            return Ok(vis);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
            //throw new APIException("VehicleController GetAllVehiclesInfos", ex);
        }
    }

    [HttpGet("{vin}", Name = "GetVehicleByVin")]
    public ActionResult<VehicleInfo> Get(string vin)
    {
        try
        {
            VehicleInfo vi = _vehicleManager.GetVehicleByVIN(vin);
            if (vi == null) return NotFound();
            return Ok(vi);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
            //throw new APIException("VehicleController GetVehicleByVin", ex);
        }
    }

    [HttpPost(Name = "addVehicle")]
    public ActionResult Add(string vin, string brandModel, string licensePlate, string fuelType, string vehicleType, string? color, int? doors, int? driverId = null)
    {
        try
        {
            VehicleInfo vi = new VehicleInfo(vin, brandModel, licensePlate, fuelType, vehicleType, color, doors, driverId);
            _vehicleManager.AddVehicle(vi);
            return Ok();
        }
        catch (Exception ex)
        {
            int code = 500;
            object? value = null;
            if (ex.InnerException is MySqlException && ex.InnerException.Message.Contains("Error Code: 1062. Duplicate entry") && ex.InnerException.Message.Contains("Vehicle.PRIMARY"))
            {
                code = 400;
                value = $"A vehicle with vin {vin} already exists.";
            }
            else if (ex.InnerException is MySqlException && ex.InnerException.Message.Contains("Error Code: 1062. Duplicate entry") && ex.InnerException.Message.Contains("Vehicle.uc_vehicle_licenseplate"))
            {
                code = 400;
                value = $"A vehicle with lp {licensePlate} already exists.";
            }
            else if (ex.InnerException is DomainException || ex.InnerException is MySqlException && ex.InnerException.Message.Contains("VIN"))
            {
                code = 400;
                value = $"{vin} is an invalid vin number.";
            }
            else if (ex.InnerException is MySqlException && ex.InnerException.Message.Contains("Error Code: 1062. Duplicate entry") && ex.InnerException.Message.Contains("Vehicle.uc_vehicle_driverid"))
            {
                code = 400;
                value = $"DriverID {driverId} already has a car.";
            }
            return StatusCode(code, value);
            //throw new APIException("VehicleController AddVehicle", ex);
        }
    }

    [HttpPut (Name = "updateVehicles")]
    public ActionResult Put(string vin, string brandModel, string licensePlate, string fuelType, string vehicleType, string? color, int? doors, int? driverId = null)
    {
        try
        {
            if (_vehicleManager.GetVehicleByVIN(vin) == null) return NotFound();
            VehicleInfo vi = new VehicleInfo(vin, brandModel, licensePlate, fuelType, vehicleType, color, doors, driverId);
            _vehicleManager.UpdateVehicle(vi);
            return Ok();
        }
        catch (Exception ex)
        {
            int code = 500;
            object? value = null;
            if (ex.InnerException is MySqlException && ex.InnerException.Message.Contains("Duplicate entry") && ex.InnerException.Message.Contains("Vehicle.PRIMARY"))
            {
                code = 400;
                value = $"A vehicle with vin {vin} already exists.";
            }
            else if (ex.InnerException is MySqlException && ex.InnerException.Message.Contains("Duplicate entry") && ex.InnerException.Message.Contains("Vehicle.uc_vehicle_licenseplate"))
            {
                code = 400;
                value = $"A vehicle with lp {licensePlate} already exists.";
            }
            else if (ex.InnerException is DomainException || ex.InnerException is MySqlException && ex.InnerException.Message.Contains("VIN"))
            {
                code = 400;
                value = $"{vin} is an invalid vin number.";
            }
            else if (ex.InnerException is MySqlException && ex.InnerException.Message.Contains("Duplicate entry") && ex.InnerException.Message.Contains("Vehicle.uc_vehicle_driverid"))
            {
                code = 400;
                value = $"DriverID {driverId} already has a car.";
            }
            return StatusCode(code, value);
            //throw new APIException("VehicleController updateVehicle", ex);
        }
    }

    [HttpDelete(Name = "DeleteVehicle")]
    public ActionResult Delete(string vin)
    {
        try
        {
            VehicleInfo vi = _vehicleManager.GetVehicleByVIN(vin);
            if (vi == null) return NotFound();
            _vehicleManager.DeleteVehicle(vi);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
            //throw new APIException("VehicleController DeleteVehicle", ex);
        }
    }
}
