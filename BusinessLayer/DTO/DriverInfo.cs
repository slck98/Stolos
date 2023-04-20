using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class DriverInfo
{
	public DriverInfo(Driver d, Vehicle? v, GasCard? gc) //(int? driverId, string firstName, string lastName, DateTime birthDate, string natRegNum, List<DriversLicense> licenses, string? address, string vin, string brandModel, string licensePlate, FuelType fuelType, VehicleType vehicleType, string? color, int? doors,int? gasCardId, string cardNum, DateTime expiringDate, int? pin, List<FuelType>? fuelTypes, bool blocked)
	{
		DriverID = d.Id;
		FirstName = d.FirstName;
		LastName = d.LastName;
		BirthDate = d.BirthDate;
		NatRegNum = d.NatRegNumber;
		Licenses = d.Licenses.ConvertAll(l=>l.ToString());
		Address = d.Address;
		if (v != null)
		{
            VehicleVin = v.VinNumber;
			VehicleLicensePlate = v.LicensePlate;
        }

        if (gc != null ) GasCardNum = gc.CardNumber;
    }

	public int? DriverID { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }
	public string NatRegNum { get; set; }
	public List<string> Licenses { get;set; }
	public string Address { get; set; }

	//tuples for vehicle + gascard
	public string? VehicleVin { get; set; }
	public string? VehicleLicensePlate { get; set; }
	public string? GasCardNum { get; set; }
}
