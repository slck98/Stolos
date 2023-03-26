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
		Licenses = d.Licenses;
		Address = d.Address;
		//if (v != null ) Vehicle = (v.VinNumber, v.BrandModel, v.LicensePlate, v.Fuel, v.Category, v.Color, v.Doors);
		//if (gc != null ) GasCard = (gc.Id, gc.CardNumber, gc.ExpiringDate, gc.Pincode, gc.Fuel, gc.Blocked);
		if (v != null) Vehicle = v;
		if (gc != null) GasCard = gc;
    }

	public int? DriverID { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }
	public string NatRegNum { get; set; }
	public List<DriversLicense> Licenses { get;set; }
	public string Address { get; set; }

	//tuples for vehicle + gascard
	//public (string? vin, string? brandModel, string? licensePlate, FuelType? fuelType, VehicleType? vehicleType, string? color, int? doors) Vehicle { get; set; }
	//public (int? id, string? cardNum, DateTime? expiringDate, int? pin, List<FuelType>? fuelTypes, bool? blocked) GasCard { get; set; }
	public Vehicle Vehicle { get; set; }
	public GasCard GasCard { get; set;}
}
