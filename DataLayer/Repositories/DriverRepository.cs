using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using BusinessLayer.Model;
using DataLayer.Exceptions;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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

                cmd = new("SELECT d.DriverID, d.FirstName, d.LastName, d.Address, d.BirthDate, d.NationalRegistrationNumber, d.DriversLicenses, v.VIN, v.LicensePlate, gc.CardNumber " +
                    "FROM GasCard gc RIGHT JOIN Driver d ON gc.DriverID=d.DriverID LEFT JOIN Vehicle v ON v.DriverID = d.DriverID WHERE d.Deleted=0 ORDER BY d.FirstName ASC;", conn);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //driver
                        int id = (int)reader["DriverID"];
                        string fName = (string)reader["FirstName"];
                        string lName = (string)reader["LastName"];
                        string? address = (string?)((reader["Address"] is DBNull) ? null : reader["Address"]);
                        DateTime birthDate = (DateTime)reader["BirthDate"];
                        string natRegNum = (string)reader["NationalRegistrationNumber"];

                        List<DriversLicense> licenseList = new List<DriversLicense>(reader["DriversLicenses"].ToString().Split(",").Select(dl => (DriversLicense)Enum.Parse(typeof(DriversLicense), dl)));

                        Driver d = DomainFactory.CreateDriver(id, lName, fName, natRegNum, licenseList, birthDate, address);
                        Vehicle? v = null;
                        GasCard? gc = null;
                        string? vin = null, licensePlate = null, gcNum = null;

                        if (reader["VIN"] is not DBNull)
                        {
                            //vehicle
                            vin = (string?)reader["VIN"];
                            licensePlate = (string?)reader["LicensePlate"];
                        }
                        if (reader["CardNumber"] is not DBNull)
                        {
                            //gascard
                            gcNum = (string?)reader["CardNumber"];
                        }

                        DriverInfo di = DriverMapper.MapEntityToDto(d, vin, licensePlate, gcNum);
                        drivers.Add(di);
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
        DriverInfo? di = null;
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("SELECT d.DriverID, d.FirstName, d.LastName, d.Address, d.BirthDate, d.NationalRegistrationNumber, d.DriversLicenses, v.VIN, v.LicensePlate, gc.CardNumber " +
                    "FROM GasCard gc RIGHT JOIN Driver d ON gc.DriverID=d.DriverID LEFT JOIN Vehicle v ON v.DriverID = d.DriverID WHERE d.Deleted=0 AND d.DriverID = @id;", conn);
                cmd.Parameters.AddWithValue("@id", driverId);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //driver
                        int id = (int)reader["DriverID"];
                        string fName = (string)reader["FirstName"];
                        string lName = (string)reader["LastName"];
                        string? address = (string?)((reader["Address"] is DBNull) ? null : reader["Address"]);
                        DateTime birthDate = (DateTime)reader["BirthDate"];
                        string natRegNum = (string)reader["NationalRegistrationNumber"];
                        List<DriversLicense> licenseList = new List<DriversLicense>(reader["DriversLicenses"].ToString().Split(",").Select(dl => (DriversLicense)Enum.Parse(typeof(DriversLicense), dl)));

                        Driver d = DomainFactory.CreateDriver(id, lName, fName, natRegNum, licenseList, birthDate, address);
                        Vehicle? v = null;
                        GasCard? gc = null;

                        string? vin = null, licensePlate = null, cardNum = null;

                        if (reader["VIN"] is not DBNull)
                        {
                            //vehicle
                            vin = (string?)reader["VIN"];
                            licensePlate = (string?)reader["LicensePlate"];
                        }
                        if (reader["CardNumber"] is not DBNull)
                        {
                            //gascard
                            cardNum = (string?)reader["CardNumber"];
                        }

                        di = DriverMapper.MapEntityToDto(d, vin, licensePlate, cardNum);
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

    public DriverInfo GetDriverInfoByNatRegNum(string natRegNum)
    {
        DriverInfo? di = null;
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("SELECT d.DriverID, d.FirstName, d.LastName, d.Address, d.BirthDate, d.NationalRegistrationNumber, d.DriversLicenses, v.VIN, v.LicensePlate, gc.CardNumber " +
                    "FROM GasCard gc RIGHT JOIN Driver d ON gc.DriverID=d.DriverID LEFT JOIN Vehicle v ON v.DriverID = d.DriverID WHERE d.NationalRegistrationNumber = @rrn;", conn);
                cmd.Parameters.AddWithValue("@rrn", natRegNum);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //driver
                        int id = (int)reader["DriverID"];
                        string fName = (string)reader["FirstName"];
                        string lName = (string)reader["LastName"];
                        string? address = (string?)((reader["Address"] is DBNull) ? null : reader["Address"]);
                        DateTime birthDate = (DateTime)reader["BirthDate"];
                        natRegNum = (string)reader["NationalRegistrationNumber"];
                        List<DriversLicense> licenseList = new List<DriversLicense>(reader["DriversLicenses"].ToString().Split(",").Select(dl => (DriversLicense)Enum.Parse(typeof(DriversLicense), dl)));

                        Driver d = DomainFactory.CreateDriver(id, lName, fName, natRegNum, licenseList, birthDate, address);
                        Vehicle? v = null;
                        GasCard? gc = null;

                        string? vin = null, licensePlate = null, cardNum = null;

                        if (reader["VIN"] is not DBNull)
                        {
                            //vehicle
                            vin = (string?)reader["VIN"];
                            licensePlate = (string?)reader["LicensePlate"];
                        }
                        if (reader["CardNumber"] is not DBNull)
                        {
                            //gascard
                            cardNum = (string?)reader["CardNumber"];
                        }

                        di = DriverMapper.MapEntityToDto(d, vin, licensePlate, cardNum);
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

    #region post
    public void AddDriver(Driver d)
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                bool existingButDeleted = ((GetDriverInfoByNatRegNum(d.NatRegNumber) != null) ? true : false);
                string sql = "";
                cmd = new(sql, conn);

                if (!existingButDeleted)
                {
                    cmd = new("INSERT INTO Driver(FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, Deleted) VALUES (@fn, @ln, @ad, @bd, @rrn, @dls, @del);", conn);

                    cmd.Parameters.AddWithValue("@fn", d.FirstName);
                    cmd.Parameters.AddWithValue("@ln", d.LastName);
                    cmd.Parameters.AddWithValue("@ad", d.Address);
                    cmd.Parameters.AddWithValue("@bd", d.BirthDate);
                    cmd.Parameters.AddWithValue("@rrn", d.NatRegNumber);
                    cmd.Parameters.AddWithValue("@dls", string.Join(",", d.Licenses.ConvertAll(dl => dl.ToString())));
                    cmd.Parameters.AddWithValue("@del", 0);
                }
                else
                {
                    cmd = new("UPDATE Driver SET Deleted=0 WHERE NationalRegistrationNumber=@rrn;", conn);

                    cmd.Parameters.AddWithValue("@rrn", d.NatRegNumber);
                }

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new DataException("DriverRepo-AddDriver", ex);
        }
    }
    #endregion

    #region put
    public void UpdateDriver(Driver d)
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("UPDATE Driver SET FirstName=@fn,LastName=@ln,Address=@ad,BirthDate=@bd,NationalRegistrationNumber=@rrn,DriversLicenses=@dls WHERE DriverID=@did;", conn);

                cmd.Parameters.AddWithValue("@did", d.Id);

                cmd.Parameters.AddWithValue("@fn", d.FirstName);
                cmd.Parameters.AddWithValue("@ln", d.LastName);
                cmd.Parameters.AddWithValue("@ad", d.Address);
                cmd.Parameters.AddWithValue("@bd", d.BirthDate);
                cmd.Parameters.AddWithValue("@rrn", d.NatRegNumber);
                cmd.Parameters.AddWithValue("@dls", string.Join(",", d.Licenses.ConvertAll(dl => dl.ToString())));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new DataException("DriverRepo-UpdateDriver", ex);
        }
    }
    #endregion

    #region delete (soft)
    public void DeleteDriver(int id)
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("UPDATE Driver SET Deleted=1 WHERE DriverID=@did;", conn);

                cmd.Parameters.AddWithValue("@did", id);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new DataException("DriverRepo-DeleteDriver", ex);
        }
    }
    #endregion
}
