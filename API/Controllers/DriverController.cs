﻿using BusinessLayer.DTO;
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

        //private static List<DriversLicense> _licenses = new List<DriversLicense> { DriversLicense.B, DriversLicense.C1};


        //private readonly List<Driver> _driver = new()
        //{
        //    new Driver(2, "Doe", "John", "85.12.31-123.40", _licenses)
        //};

        public DriverController(ILogger<DriverController> logger, IConfiguration iConfig)
        {
            this.logger = logger;
            this.iConfig = iConfig;

            _driverManager = new DriverManager(new DriverRepository(iConfig.GetValue<string>("ConnectionStrings:stolos")));
        }

        [HttpGet(Name = "GetDriverInfos")]
        public List<DriverInfo> Get()
        {
            return _driverManager.GetDriverInfos();
        }

        //[HttpGet("{id}", Name = "GetDriver")]
        //public Driver Get(int id)
        //{
        //    return _driverManager.GetDriverById(id);
        //}

        [HttpGet("{id}", Name = "GetDriverInfo")]
        public DriverInfo Get(int id)
        {
            return _driverManager.GetDriverInfoById(id);
        }
    }
}
