using API.Exceptions;
using BusinessLayer.DTO;
using BusinessLayer.Managers;
using BusinessLayer.Model;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace API.Controllers
{
    [ApiController] // voor DI
    [Route("[controller]")] // wordt .../GasCard
    public class GasCardController : Controller
    {
        private readonly ILogger<GasCardController> logger;
        private GasCardManager _gasCardManager;

        public GasCardController(ILogger<GasCardController> logger, IConfiguration config)
        {
            this.logger = logger;
            _gasCardManager = new GasCardManager(new GasCardRepository(config.GetValue<string>("ConnectionStrings:stolos")));
        }

        [HttpGet(Name = "GetGasCards")]
        public List<GasCardInfo> Get()
        {
            try
            {
                return _gasCardManager.GetAllGasCardsInfos();
            }
            catch (Exception ex)
            {
                throw new APIException("GasCardController GetAllGasCardInfos", ex);
            }
        }
    }
}
