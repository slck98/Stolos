using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class GasCardManager
    {
        public IGasCardRepository _repo;

        public GasCardManager(IGasCardRepository repo)
        {
            _repo = repo;
        }
        public List<GasCard> GetAllGasCards()
        {
            return _repo.GetAllGasCards();
        }

        public GasCard GetGasCard(string cn)
        {
            return _repo.GetGasCard(cn);
        }

        public List<GasCardInfo> GetAllGasCardsInfos()
        {
            return _repo.GetGasCardInfos();
        }

        public GasCardInfo GetGasCardInfo(string cn)
        {
            return _repo.GetGasCardInfo(cn);
        }
    }
}
