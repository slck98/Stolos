using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class VehicleInfo
{
	public VehicleInfo(string vin, string brandModel, string licensePlate, FuelType fuel, VehicleType vehicleType, string? color, int? doors, int? dId)
	{
		VIN = vin;
		BrandModel = brandModel;
		LicensePlate = licensePlate;
		FuelType = fuel.ToString();
		VehicleType = vehicleType.ToString();
		Color = color;
		Doors = doors;
        if (dId != null) DriverId = dId;
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
