using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
        List<Driver> drivers = new List<Driver>();
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
                        string? address = (string?)((reader[3] is DBNull)?"": reader[3]);
                        DateTime birthDate = (DateTime)reader[4];
                        string natRegNum = (string)reader[5];
                        List<DriversLicense> licenseList = new List<DriversLicense>();
                        string licensesDB = (string)reader[6];
                        string[] lArrStrs = licensesDB.Split(",");
                        foreach (string lArrStr in lArrStrs)
                        {
                            licenseList.Add((DriversLicense)Enum.Parse(typeof(DriversLicense), lArrStr));
                        }

                        //todo vehicle (vin)
                        //todo gascard (id/cardnum?)


                        Driver d = new(id, lName, fName, birthDate, natRegNum, licenseList, address);
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

    public Driver GetDriver(int id)
    {
        Driver d = null;
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("SELECT * FROM Driver WHERE ID=" + id.ToString() + " AND Deleted=0;", conn);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string fName = (string)reader[1];
                        string lName = (string)reader[2];
                        string? address = (string?)((reader[3] is DBNull) ? "" : reader[3]);
                        DateTime birthDate = (DateTime)reader[4];
                        string natRegNum = (string)reader[5];
                        List<DriversLicense> licenseList = new List<DriversLicense>();
                        string licensesDB = (string)reader[6];
                        string[] lArrStrs = licensesDB.Split(",");
                        foreach (string lArrStr in lArrStrs)
                        {
                            licenseList.Add((DriversLicense)Enum.Parse(typeof(DriversLicense), lArrStr));
                        }

                        //todo vehicle (vin)
                        //todo gascard (id/cardnum?)


                        d = new(id, lName, fName, birthDate, natRegNum, licenseList, address);
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
    #endregion
}
