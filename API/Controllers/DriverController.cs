using API.Exceptions;
using BusinessLayer.DTO;
using BusinessLayer.Managers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public List<DriverInfo> Get()
        {
            try
            {
                return _driverManager.GetDriverInfos();
            }
            catch (Exception ex)
            {
                throw new APIException("DriverController GetDriverInfos", ex);
            }
        }

        [HttpGet("{id}", Name = "GetDriverInfo")]
        public DriverInfo Get(int id)
        {
            try
            {
                return _driverManager.GetDriverInfoById(id);
            }
            catch (Exception ex)
            {
                throw new APIException("DriverController GetDriverInfoById(id)", ex);
            }
        }
    }
}
