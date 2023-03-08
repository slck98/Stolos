using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BussinessLayer.Model.Vehicle;

namespace BussinessLayer.Model
{
    public class TankCard
    {
        public TankCard(string cardNumber, DateTime expiringDate, int? pincode, bool blocked, List<FuelType> feul)
        {
            CardNumber = cardNumber;
            ExpiringDate = expiringDate;
            Pincode = pincode;
            Blocked = blocked;
            Fuel = feul;
        }

        public string CardNumber { get; set; }
        public DateTime ExpiringDate { get; set; }
        public int? Pincode { get; set; }
        public bool Blocked { get; set; }
        public List<FuelType> Fuel { get; set; }
    }
}
