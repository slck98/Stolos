using BusinessLayer.DTO;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers;

public static class DriverMapper
{
    public static Driver MapDtoToEntity(DriverInfo di)
    {
        return new Driver(di.DriverID, di.LastName, di.FirstName, di.NatRegNum, di.Licenses.ConvertAll(dl => (DriversLicense)Enum.Parse(typeof(DriversLicense), dl)), di.BirthDate, di.Address);
    }

    public static DriverInfo MapEntityToDto(Driver d, string vehVin = null, string vehLP = null, string gcNum = null)
    {
        return new DriverInfo(d.Id, d.FirstName, d.LastName, d.BirthDate, d.NatRegNumber, d.Licenses.ConvertAll(dl => dl.ToString()), d.Address, vehVin, vehLP, gcNum);
    }
}
