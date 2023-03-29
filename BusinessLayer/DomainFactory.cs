using BusinessLayer.DTO;
using BusinessLayer.Exceptions;
using BusinessLayer.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer;

public class DomainFactory
{
    public static Driver NewDriver(DriverInfo di)
    {
        try
        {
            return new Driver(di.DriverID, di.LastName, di.FirstName, di.NatRegNum, di.Licenses, di.BirthDate, di.Address);
        }
        catch (Exception ex)
        {
            throw new DomainException("DomainFactory - NewDriver", ex);
        }
    }

    public static Driver ExistingDriver(int? id, string lastName, string firstName, string natRegNumber, List<DriversLicense> licenses, DateTime? birthDate = null, string? address = null)
    {
        try
        {
            return new Driver(id, lastName, firstName, natRegNumber, licenses, birthDate, address);
        }
        catch (Exception ex)
        {
            throw new DomainException("DomainFactory - NewDriver", ex);
        }
    }

    public static Vehicle NewVehicle(VehicleInfo vi)
    {
        try
        {
            return new Vehicle(vi.VIN, vi.BrandModel, vi.LicensePlate, vi.VehicleType, vi.FuelType, vi.Color, vi.Doors);
        }
        catch (Exception ex)
        {
            throw new DomainException("DomainFactory - NewVehicle", ex);
        }
    }

    public static Vehicle ExistingVehicle(string vin, string brandModel, string plate, VehicleType vehicleType, FuelType fuelType, string? color, int? doors)
    {
        try
        {
            return new(vin, brandModel, plate, vehicleType, fuelType, color, doors);
        }
        catch (Exception ex)
        {
            throw new DomainException("DomainFactory - NewVehicle", ex);
        }
    }

    public static GasCard NewGasCard(GasCardInfo gasCardInfo)
    {
        try
        {
            return new GasCard(gasCardInfo.GasCardID, gasCardInfo.CardNumber, gasCardInfo.ExpiringDate, gasCardInfo.Pincode, gasCardInfo.Blocked, gasCardInfo.FuelTypes);
        }
        catch (Exception ex)
        {
            throw new DomainException("DomainFactory - NewGasCard", ex);
        }
    }

    public static GasCard ExistingGasCard(int? id, string cardNum, DateTime expiringDate, int? pin, List<FuelType> fuelTypes, bool blocked)
    {
        try
        {
            return new GasCard(id, cardNum, expiringDate, pin, blocked, fuelTypes);
        }
        catch (Exception ex)
        {
            throw new DomainException("DomainFactory - NewGasCard", ex);
        }
    }
}
