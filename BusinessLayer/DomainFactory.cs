using BusinessLayer.DTO;
using BusinessLayer.Exceptions;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
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
            return new Driver(di.DriverID, di.LastName, di.FirstName, di.BirthDate, di.NatRegNum, di.Licenses, di.Address);
        }
        catch (Exception ex)
        {
            throw new DomainException("DomainFactory - NewDriver", ex);
        }
    }

    public static Driver ExistingDriver(int? id, string lastName, string firstName, DateTime? birthDate, string natRegNumber, List<DriversLicense> licenses, string address = null)
    {
        try
        {
            return new Driver(id, lastName, firstName, birthDate, natRegNumber, licenses, address);
        }
        catch (Exception ex)
        {
            throw new DomainException("DomainFactory - NewDriver", ex);
        }
    }

    //public static Driver NewVehicle()
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new DomainException("DomainFactory - NewDriver", ex);
    //    }
    //}

    //public static Driver ExistingVehicle()
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new DomainException("DomainFactory - NewDriver", ex);
    //    }
    //}

    //public static Driver NewGasCard()
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new DomainException("DomainFactory - NewDriver", ex);
    //    }
    //}

    //public static Driver ExistingGasCard()
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new DomainException("DomainFactory - NewDriver", ex);
    //    }
    //}
}
