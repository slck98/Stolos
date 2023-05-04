using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class DriverInfo
{
    public int? DriverID { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public string NatRegNum { get; set; }
    [Required]
    public List<string> Licenses { get; set; }
    [Required]
    public string Address { get; set; }

    //foreign obj data
    public string? VehicleVin { get; set; }
    public string? GasCardNum { get; set; }

    //ctor
    public DriverInfo(int? driverId, string firstName, string lastName, DateTime birthDate, string natRegNum, List<string> licenses, string address, string? vehicleVin = null, string? gasCardNum = null)
    {
        DriverID = driverId;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        NatRegNum = natRegNum;
        Licenses = licenses;
        Address = address;
        if (!string.IsNullOrEmpty(vehicleVin)) VehicleVin = vehicleVin;

        if (!string.IsNullOrEmpty(gasCardNum)) GasCardNum = gasCardNum;
    }

    //props to match ctor param
    public int? DriverDriverID => DriverID;
    public string DriverFirstName => FirstName;
    public string DriverLastName => LastName;
    public DateTime DriverBirthDate => BirthDate;
    public string DriverNatRegNum => NatRegNum;
    public List<string> DriverLicenses => Licenses;
    public string DriverAddress => Address;
    public string? DriverVehicleVin => VehicleVin;
    public string? DriverGasCardNum => GasCardNum;
}
