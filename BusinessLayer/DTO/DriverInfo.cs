using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class DriverInfo
{
    public DriverInfo(int? id, string fname, string lname, DateTime birthDate, string natRegNum, List<string> licenses, string address, string? vehVin, string? gcNum)
    {
        DriverID = id;
        FirstName = fname;
        LastName = lname;
        BirthDate = birthDate;
        NatRegNum = natRegNum;
        Licenses = licenses;
        Address = address;
        if (!string.IsNullOrEmpty(vehVin)) VehicleVin = vehVin;

        if (gcNum != null) GasCardNum = gcNum;
    }

	public int? DriverID { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }
	public string NatRegNum { get; set; }
	public List<string> Licenses { get;set; }
	public string Address { get; set; }

	//foreign obj data
	public string? VehicleVin { get; set; }
	public string? GasCardNum { get; set; }
}
