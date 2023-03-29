using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Exceptions;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories;

/*
 * Adrian B on 17/03
 */
public class VehicleRepository : IVehicleRepository
{
    #region attrib
    private string _connectionString;
    #endregion

    #region ctor
    public VehicleRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    #endregion

    #region get
    public List<VehicleInfo> GetAllVehicleInfos()
    {
        List<VehicleInfo> vehicles = new();
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("SELECT * FROM Vehicle v JOIN Driver d WHERE v.Deleted=0;", conn);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //vehicle
                        string vinDB = (string)reader[0];
                        string brandModel = (string)reader[1];
                        string plate = (string)reader[2];
                        FuelType fuelType = (FuelType)reader[3];
                        VehicleType vehicleType = (VehicleType)reader[4];
                        string? color = (string?)((reader[5] is DBNull) ? "" : reader[5]);
                        int? doors = (int?)((reader[6] is DBNull) ? null : reader[6]);
                        int? driverId = (int?)((reader[7] is DBNull) ? null : reader[7]);

                        Vehicle v = DomainFactory.ExistingVehicle(vinDB, brandModel, plate, vehicleType, fuelType, color, doors);
                        Driver? d = null;

                        if (reader["DriverId"] is not DBNull)
                        {
                            //Driver
                            int id = (int)reader["DriverId"];
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

                            d = DomainFactory.ExistingDriver(id, lName, fName, natRegNum, licenseList, birthDate, address);
                        }

                        VehicleInfo vehicleInfo = new(v, d);
                        vehicles.Add(vehicleInfo);
                    }
                    reader.Close();
                }

                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new DataException("VehicleRepo-GetAllVehicles", ex);
        }
        return vehicles;
    }

    public VehicleInfo GetVehicleByVIN(string vin)
    {
        VehicleInfo vehicle;
        Vehicle v = null;
        Driver? d = null;
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("SELECT * FROM Vehicle v JOIN Driver d WHERE VIN = @vin AND v.Deleted=0;", conn);
                cmd.Parameters.AddWithValue("@vin", vin);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //vehicle
                        string vinDB = (string)reader[0];
                        string brandModel = (string)reader[1];
                        string plate = (string)reader[2];
                        FuelType fuelType = (FuelType)reader[3];
                        VehicleType vehicleType = (VehicleType)reader[4];
                        string? color = (string?)((reader[5] is DBNull) ? "" : reader[5]);
                        int? doors = (int?)((reader[6] is DBNull) ? null : reader[6]);
                        int? driverId = (int?)((reader[7] is DBNull) ? null : reader[7]);

                        if (reader["DriverId"] is not DBNull)
                        {
                            //Driver
                            int id = (int)reader["DriverId"];
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

                            d = DomainFactory.ExistingDriver(id, lName, fName, natRegNum, licenseList, birthDate, address);
                        }

                        v = DomainFactory.ExistingVehicle(vinDB, brandModel, plate, vehicleType, fuelType, color, doors);

                    }
                    reader.Close();
                }

                conn.Close();
            }
            vehicle = new VehicleInfo(v, d);
        }
        catch (Exception ex)
        {
            throw new DataException("VehicleRepo-GetVehicle", ex);
        }
        return vehicle;
    }
    #endregion

    #region post
    public void AddVehicle(Vehicle vehicle)
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("INSERT INTO db_allphifm.Driver (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID) VALUES (@vin, @bm, @lp, @ft, @vt, @clr, @drs, @did);", conn);

                cmd.Parameters.AddWithValue("@vin", vehicle.VinNumber);
                cmd.Parameters.AddWithValue("@bm", vehicle.BrandModel);
                cmd.Parameters.AddWithValue("@lp", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("@ft", vehicle.Fuel);
                cmd.Parameters.AddWithValue("@vt", vehicle.Category);
                cmd.Parameters.AddWithValue("@clr", vehicle.Color);
                cmd.Parameters.AddWithValue("@drs", vehicle.Doors);
                //cmd.Parameters.AddWithValue("@did", vehicle.Driver.Id);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new DataException("VehicleRepo-AddVehicle", ex);
        }
    }
    #endregion

    #region patch
    #endregion
}
