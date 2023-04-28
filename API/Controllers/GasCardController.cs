using API.Exceptions;
using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Managers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController] // voor DI
[Route("[controller]")] // wordt .../GasCard
public class GasCardController : Controller {
    private readonly ILogger<GasCardController> logger;
    private IConfiguration iConfig;
    private GasCardManager _gasCardManager;

    public GasCardController(ILogger<GasCardController> logger, IConfiguration config) {
        this.logger = logger;
        this.iConfig = config;
        _gasCardManager = new GasCardManager(new GasCardRepository(iConfig.GetValue<string>("ConnectionStrings:stolos")));
    }

    [HttpGet(Name = "GetGasCards")]
    public ActionResult<List<GasCardInfo>> Get() {
        try
        {
            List<GasCardInfo> gcis = _gasCardManager.GetAllGasCardsInfos();
            if (gcis == null) return NotFound();
            return Ok(gcis);
        } catch (Exception ex) {
            return StatusCode(500);
            //throw new APIException("GasCardController GetAllGasCardInfos", ex);
        }
    }

    [HttpGet("{cardNum}", Name = "GetGasCardsInfos")]
    public ActionResult<GasCardInfo> Get(string cardNum) {
        try
        {
            GasCardInfo gci = _gasCardManager.GetGasCardInfo(cardNum);
            if (gci == null) return NotFound();
            return Ok(gci);
        } catch (Exception ex) {
            return StatusCode(500);
            //throw new APIException($"DriverController GetDriverInfoById({cardNum})", ex);
        }
    }

    [HttpPost(Name = "addGasCard")]
    public ActionResult Add(string cardNumber, DateTime expiringDate, int? pincode, bool blocked, List<string> fuel, int? driverId = null) {
        try
        {
            GasCardInfo gci = new GasCardInfo(cardNumber, expiringDate, pincode, fuel, blocked, driverId);
            _gasCardManager.AddGasCard(gci);
            return Ok();
        } catch (Exception ex) {

            throw new APIException("GasCardController AddGasCard", ex);
        }
    }

    [HttpPut(Name = "updateGasCard")]
    public ActionResult Put(string cardNumber, DateTime expiringDate, int? pincode, bool blocked, List<string> fuel, int? driverId = null)
    {
        try
        {
            if (_gasCardManager.GetGasCardInfo(cardNumber) == null) return NotFound();
            GasCardInfo gci = new GasCardInfo(cardNumber, expiringDate, pincode, fuel, blocked, driverId);
            _gasCardManager.UpdateGasCard(gci);
            return Ok();
        }
        catch (Exception ex)
        {
            throw new APIException("GasCardController updateGasCard", ex);
        }
    }

    [HttpDelete(Name = "DeleteGasCard")]
    public ActionResult Delete(string cn)
    {
        try
        {
            GasCardInfo gci = _gasCardManager.GetGasCardInfo(cn);
            if (gci == null) return NotFound();
            _gasCardManager.DeleteGasCard(gci);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
            //throw new APIException("GasCardController DeleteGasCard", ex);
        }
    }
}
