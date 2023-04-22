using BusinessLayer.Exceptions;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class GasCardInfo
{
	public GasCardInfo(GasCard gc, int? dId)
	{
		CardNumber = gc.CardNumber;
		ExpiringDate = gc.ExpiringDate;
		Pincode = gc.Pincode;
		FuelTypes = gc.Fuel.ConvertAll(l => l.ToString());
		Blocked = gc.Blocked;

		if (dId != null) DriverId= dId;
    }

    public GasCardInfo(GasCard gc, Driver? d) : this(gc, d.Id){ }

    public string CardNumber { get; set; }
	public DateTime ExpiringDate { get; set; }
	public int? Pincode { get; set; }
	public List<string>? FuelTypes { get; set; }
	public bool Blocked { get; set; }

    public int? DriverId { get; set; }
}
