using API.Exceptions;
using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Managers;
using BusinessLayer.Mappers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("[controller]")] // wordt .../Driver

    public class DriverController : Controller
    {
        private readonly ILogger<DriverController> logger;
        private IConfiguration iConfig;
        private DriverManager _driverManager;

        public DriverController(ILogger<DriverController> logger, IConfiguration config)
        {
            this.logger = logger;
            this.iConfig = config;

            _driverManager = new DriverManager(new DriverRepository(iConfig.GetValue<string>("ConnectionStrings:stolos")));
        }

        [HttpGet(Name = "GetDriverInfos")]
        public ActionResult<List<DriverInfo>> Get()
        {
            try
            {
                List <DriverInfo> driverInfos = _driverManager.GetDriverInfos();
                if (driverInfos == null) return NotFound();
                return Ok(driverInfos);
            }
            catch (Exception ex)
            {
                throw new APIException("DriverController GetDriverInfos", ex);
            }
        }

        [HttpGet("{id}", Name = "GetDriverInfo")]
        public ActionResult<DriverInfo> Get(int id)
        {
            try
            {
                DriverInfo di = _driverManager.GetDriverInfoById(id);
                if (di == null) return NotFound();
                return Ok(di);
            }
            catch (Exception ex)
            {
                throw new APIException($"DriverController GetDriverInfoById({id})", ex);
            }
        }

        [HttpPost(Name = "AddDriver")]
        public ActionResult Add(string fname, string lname, string address, DateTime birthDate, string natRegNum, List<string> driversLicenses)
        {
            try
            {
                DriverInfo di = new(null, fname, lname, birthDate, natRegNum, driversLicenses, address, null, null, null);
                _driverManager.AddDriver(di);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new APIException("DriverController AddDriver", ex);
            }
        }

        [HttpPut(Name = "UpdateDriver")]
        public ActionResult Put(int id, string fname, string lname, string address, DateTime birthDate, string natRegNum, List<string> driversLicenses)
        {
            try
            {
                if (_driverManager.GetDriverInfoById(id) == null) return NotFound();
                DriverInfo di = new(id, fname, lname, birthDate, natRegNum, driversLicenses, address, null, null, null);

                _driverManager.UpdateDriver(di);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new APIException("DriverController UpdateDriver", ex);
            }
        }

        [HttpDelete(Name = "DeleteDriver")]
        public ActionResult Delete(int id)
        {
            try
            {
                //soft delete
                DriverInfo di = _driverManager.GetDriverInfoById(id);
                if (di == null) return NotFound();
                _driverManager.DeleteDriver((int)di.DriverID);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new APIException("DriverController DeleteDriver", ex);
            }
        }
    }
}
