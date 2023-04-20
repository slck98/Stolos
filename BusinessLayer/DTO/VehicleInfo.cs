using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class VehicleInfo
{
	public VehicleInfo(Vehicle v, Driver? d)
	{
		VIN = v.VinNumber;
		BrandModel = v.BrandModel;
		LicensePlate = v.LicensePlate;
		FuelType = v.Fuel.ToString();
		VehicleType = v.Category.ToString();
		Color = v.Color;
		Doors = v.Doors;
        if (d != null) DriverId = d.Id;
    }

	public string VIN { get; set; }
	public string BrandModel { get; set; }
	public string LicensePlate { get; set; }
	public string FuelType { get; set; }
	public string VehicleType { get; set; }
	public string? Color { get; set; }
	public int? Doors { get; set; }
	public int? DriverId { get; set; }
}
