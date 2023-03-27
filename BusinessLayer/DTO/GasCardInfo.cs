using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class GasCardInfo
{
	public GasCardInfo(GasCard gc, Driver? d)
	{
		GasCardID = gc.Id;
		CardNumber = gc.CardNumber;
		ExpiringDate = gc.ExpiringDate;
		Pincode = gc.Pincode;
		FuelTypes = gc.Fuel;
		Blocked = gc.Blocked;

        if (d != null) Driver = d;
    }

	public int? GasCardID { get; set; }
	public string CardNumber { get; set; }
	public DateTime ExpiringDate { get; set; }
	public int? Pincode { get; set; }
	public List<FuelType>? FuelTypes { get; set; }
	public bool Blocked { get; set; }
	public Driver? Driver { get; set; }
}
