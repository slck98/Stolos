using API.Exceptions;
using BusinessLayer.DTO;
using BusinessLayer.Managers;
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

        public DriverController(ILogger<DriverController> logger, IConfiguration iConfig)
        {
            this.logger = logger;
            this.iConfig = iConfig;

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
    }
}
