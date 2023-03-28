using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories;

public class DriverRepository : IDriverRepository
{
    #region priv attrib
    private string _connectionString;
    #endregion

    #region ctor
    public DriverRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    #endregion

    #region get
    public List<Driver> GetAllDrivers()
    {
        List<Driver> drivers = new();
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))

            {
                conn.Open();

                cmd = new("SELECT * FROM Driver WHERE Deleted=0;", conn);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader[0];
                        string fName = (string)reader[1];
                        string lName = (string)reader[2];
                        string? address = (string?)((reader[3] is DBNull) ? null : reader[3]);
                        DateTime birthDate = (DateTime)reader[4];
                        string natRegNum = (string)reader[5];
                        List<DriversLicense> licenseList = new();
                        string licensesDB = (string)reader[6];
                        string[] lArrStrs = licensesDB.Split(",");
                        foreach (string lArrStr in lArrStrs)
                        {
                            licenseList.Add((DriversLicense)Enum.Parse(typeof(DriversLicense), lArrStr));
                        }


                        Driver d = DomainFactory.ExistingDriver(id, lName, fName, natRegNum, licenseList, birthDate, address);
                        drivers.Add(d);
                    }
                    reader.Close();
                }

                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new DataException("DriverRepo-GetAllDrivers", ex);
        }
        return drivers;
    }

    public Driver GetDriverById(int id)
    {
        Driver? d = null;
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("SELECT * FROM Driver WHERE DriverID=" + id.ToString() + " AND Deleted=0;", conn);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string fName = (string)reader[1];
                        string lName = (string)reader[2];
                        string? address = (string?)((reader[3] is DBNull) ? null : reader[3]);
                        DateTime birthDate = (DateTime)reader[4];
                        string natRegNum = (string)reader[5];
                        List<DriversLicense> licenseList = new();
                        string licensesDB = (string)reader[6];
                        string[] lArrStrs = licensesDB.Split(",");
                        foreach (string lArrStr in lArrStrs)
                        {
                            licenseList.Add((DriversLicense)Enum.Parse(typeof(DriversLicense), lArrStr));
                        }


                        d = DomainFactory.ExistingDriver(id, lName, fName, natRegNum, licenseList, birthDate, address);
                    }
                    reader.Close();
                }

                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new DataException("DriverRepo-GetDriver", ex);
        }
        return d;
    }

    public List<DriverInfo> GetAllDriverInfos()
    {
        List<DriverInfo> drivers = new();
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))

            {
                conn.Open();

                cmd = new("SELECT * FROM GasCard gc RIGHT JOIN Driver d ON gc.DriverID=d.DriverID LEFT JOIN Vehicle v ON v.DriverID = d.DriverID WHERE d.Deleted=0;", conn);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //driver
                        int id = (int)reader[8];
                        string fName = (string)reader["FirstName"];
                        string lName = (string)reader["LastName"];
                        string? address = (string?)((reader["Address"] is DBNull) ? null : reader["Address"]);
                        DateTime birthDate = (DateTime)reader["BirthDate"];
                        string natRegNum = (string)reader["NationalRegistrationNumber"];
                        List<DriversLicense> licenseList = new();
                        string licensesDB = (string)reader["DriversLicenses"];
                        string[] lArrStrs = licensesDB.Split(",");
                        foreach (string lArrStr in lArrStrs)
                        {
                            licenseList.Add((DriversLicense)Enum.Parse(typeof(DriversLicense), lArrStr));
                        }

                        Driver d = DomainFactory.ExistingDriver(id, lName, fName, natRegNum, licenseList, birthDate, address);
                        Vehicle? v = null;
                        GasCard? gc = null;

                        if (reader["VIN"] is not DBNull)
                        {
                            //vehicle
                            string vin = (string)reader["VIN"];
                            string brandModel = (string)reader["BrandModel"];
                            string licensePlate = (string)reader["LicensePlate"];
                            FuelType fuelType = (FuelType)reader["FuelType"];
                            VehicleType vehicleType = (VehicleType)reader["VehicleType"];
                            string? color = (string)reader["Color"];
                            int? doors = (int?)reader["Doors"];
                            v = new(vin, licensePlate, brandModel, vehicleType, fuelType, color, doors);
                        }
                        if (reader[0] is not DBNull)
                        {
                            //gascard
                            int gasCardId = (int)reader[0];
                            string cardNum = (string)reader["CardNumber"];
                            DateTime expiringDate = (DateTime)reader["ExpiringDate"];
                            int? pin = (int)reader["Pincode"];
                            List<FuelType> fuelTypeList = new();
                            string fuelTypesDB = (string)reader["FuelTypes"];
                            string[] ftsArrStrs = fuelTypesDB.Split(",");
                            foreach (string ftsArrStr in ftsArrStrs)
                            {
                                fuelTypeList.Add((FuelType)Enum.Parse(typeof(FuelType), ftsArrStr));
                            }
                            bool blocked = Convert.ToBoolean((int)reader["Blocked"]);
                            gc = DomainFactory.ExistingGasCard(gasCardId, cardNum, expiringDate, pin, fuelTypeList, blocked);
                        }

                        DriverInfo driverInfo = new(d, v, gc);
                        drivers.Add(driverInfo);
                    }
                    reader.Close();
                }

                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new DataException("DriverRepo-GetAllDrivers", ex);
        }
        return drivers;
    }

    public DriverInfo GetDriverInfoById(int driverId)
    {
        DriverInfo di = null;
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("SELECT * FROM GasCard gc RIGHT JOIN Driver d ON gc.DriverID=d.DriverID LEFT JOIN Vehicle v ON v.DriverID = d.DriverID WHERE d.Deleted=0 AND d.DriverID = " + driverId.ToString() + ";", conn);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //driver
                        int id = (int)reader[8];
                        string fName = (string)reader["FirstName"];
                        string lName = (string)reader["LastName"];
                        string? address = (string?)((reader["Address"] is DBNull) ? null : reader["Address"]);
                        DateTime birthDate = (DateTime)reader["BirthDate"];
                        string natRegNum = (string)reader["NationalRegistrationNumber"];
                        List<DriversLicense> licenseList = new();
                        string licensesDB = (string)reader["DriversLicenses"];
                        string[] lArrStrs = licensesDB.Split(",");
                        foreach (string lArrStr in lArrStrs)
                        {
                            licenseList.Add((DriversLicense)Enum.Parse(typeof(DriversLicense), lArrStr));
                        }

                        Driver d = DomainFactory.ExistingDriver(id, lName, fName, natRegNum, licenseList, birthDate, address);
                        Vehicle? v = null;
                        GasCard? gc = null;

                        if (reader["VIN"] is not DBNull)
                        {
                            //vehicle
                            string vin = (string)reader["VIN"];
                            string brandModel = (string)reader["BrandModel"];
                            string licensePlate = (string)reader["LicensePlate"];
                            FuelType fuelType = (FuelType)reader["FuelType"];
                            VehicleType vehicleType = (VehicleType)reader["VehicleType"];
                            string? color = (string)reader["Color"];
                            int? doors = (int?)reader["Doors"];
                            v = new(vin, licensePlate, brandModel, vehicleType, fuelType, color, doors);
                        }
                        if (reader[0] is not DBNull)
                        {
                            //gascard
                            int gasCardId = (int)reader[0];
                            string cardNum = (string)reader["CardNumber"];
                            DateTime expiringDate = (DateTime)reader["ExpiringDate"];
                            int? pin = (int)reader["Pincode"];
                            List<FuelType> fuelTypeList = new();
                            string fuelTypesDB = (string)reader["FuelTypes"];
                            string[] ftsArrStrs = fuelTypesDB.Split(",");
                            foreach (string ftsArrStr in ftsArrStrs)
                            {
                                fuelTypeList.Add((FuelType)Enum.Parse(typeof(FuelType), ftsArrStr));
                            }
                            bool blocked = Convert.ToBoolean((int)reader["Blocked"]);
                            gc = DomainFactory.ExistingGasCard(gasCardId, cardNum, expiringDate, pin, fuelTypeList, blocked);
                        }

                        di = new(d, v, gc);
                    }
                    reader.Close();
                }
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new DataException("DriverRepo-GetDriver", ex);
        }
        return di;
    }
    #endregion
}
