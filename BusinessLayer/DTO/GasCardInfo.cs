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
	public GasCardInfo(string gcNum, DateTime expiringDate, int? pin, List<FuelType> fuelTypes, bool blocked, int? dId)
	{
		CardNumber = gcNum;
		ExpiringDate = expiringDate;
		Pincode = pin;
		FuelTypes = fuelTypes.ConvertAll(l => l.ToString());
		Blocked = blocked;

		if (dId != null) DriverId= dId;
    }

    public string CardNumber { get; set; }
	public DateTime ExpiringDate { get; set; }
	public int? Pincode { get; set; }
	public List<string>? FuelTypes { get; set; }
	public bool Blocked { get; set; }

    public int? DriverId { get; set; }
}
