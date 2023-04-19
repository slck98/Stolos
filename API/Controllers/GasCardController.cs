using API.Exceptions;
using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Managers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace API.Controllers;

[ApiController] // voor DI
[Route("[controller]")] // wordt .../GasCard
public class GasCardController : Controller
{
    private readonly ILogger<GasCardController> logger;
    private IConfiguration iConfig;
    private GasCardManager _gasCardManager;

    public GasCardController(ILogger<GasCardController> logger, IConfiguration config)
    {
        this.logger = logger;
        this.iConfig = config;
        _gasCardManager = new GasCardManager(new GasCardRepository(iConfig.GetValue<string>("ConnectionStrings:stolos")));
    }

    [HttpGet(Name = "GetGasCards")]
    public ActionResult<List<GasCardInfo>> Get()
    {
        try
        {
            List<GasCardInfo> gcis = _gasCardManager.GetAllGasCardsInfos();
            if (gcis == null) return NotFound();
            return gcis;
        }
        catch (Exception ex)
        {
            throw new APIException("GasCardController GetAllGasCardInfos", ex);
        }
    }

    [HttpGet("{cardnum}", Name = "GetGasCardsInfos")]
    public ActionResult<GasCardInfo> Get(string cardNum)
    {
        try
        {
            GasCardInfo gci = _gasCardManager.GetGasCardInfo(cardNum);
            if (gci == null) return NotFound();
            return Ok(gci);
        }
        catch (Exception ex)
        {
            throw new APIException($"DriverController GetDriverInfoById({cardNum})", ex);
        }
    }

    [HttpPost(Name = "addGasCard")]
    public OkResult Add(string cardNumber, DateTime expiringDate, int? pincode, bool blocked, List<FuelType> fuel)
    {
        try
        {
            if (string.IsNullOrEmpty(cardNumber)) throw new Exception();
            GasCard gc = DomainFactory.CreateGasCard(cardNumber, expiringDate, pincode, fuel, blocked);
            _gasCardManager.AddGasCard(gc);
            return Ok();
        }
        catch (Exception ex)
        {
            throw new APIException("GasCardController AddGasCard", ex);
        }
    }
}
