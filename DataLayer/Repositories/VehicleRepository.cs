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
    public List<Vehicle> GetAllVehicles()
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn= new(_connectionString))

            {
                conn.Open();

                cmd = new ("SELECT * FROM Vehicle WHERE Deleted=0;", conn);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string vin = (string)reader[0];
                        string brandModel = (string)reader[1];
                        string plate = (string)reader[2];
                        FuelType fuelType = (FuelType)reader[3];
                        VehicleType vehicleType = (VehicleType)reader[4];
                        string? color = (string?)((reader[5] is DBNull)?"":reader[5]);
                        int? doors = (int?)((reader[6] is DBNull) ? null : reader[6]);
                        int? driverId = (int?)((reader[7] is DBNull) ? null : reader[7]);

                        //todo driver (id/natregnum?)

                        Vehicle v = new Vehicle(vin, plate, brandModel, vehicleType, fuelType, color, doors, null);
                        vehicles.Add(v);
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

    public Vehicle GetVehicleByVIN(string vin)
    {
        Vehicle v = null;
        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;
        try
        {
            using (conn = new(_connectionString))
            {
                conn.Open();

                cmd = new("SELECT * FROM Vehicle WHERE VIN='" + vin + "' AND Deleted=0;", conn);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string vinDB = (string)reader[0];
                        string brandModel = (string)reader[1];
                        string plate = (string)reader[2];
                        FuelType fuelType = (FuelType)reader[3];
                        VehicleType vehicleType = (VehicleType)reader[4];
                        string? color = (string?)((reader[5] is DBNull) ? "" : reader[5]);
                        int? doors = (int?)((reader[6] is DBNull) ? null : reader[6]);
                        int? driverId = (int?)((reader[7] is DBNull) ? null: reader[7]);

                        v = new Vehicle(vinDB, plate, brandModel, vehicleType, fuelType, color, doors, null);
                    }
                    reader.Close();
                }

                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new DataException("VehicleRepo-GetVehicle", ex);
        }
        return v;
    }
    #endregion

    #region put
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
                cmd.Parameters.AddWithValue("@did", vehicle.Driver.Id);

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

    #region update
    #endregion
}
