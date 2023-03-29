﻿using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class GasCardRepository : IGasCardRepository
    {
        public string _connectionString;

        public GasCardRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public GasCard GetGasCard(string cardNum)
        {
            GasCard card = null;
            MySqlConnection conn;
            MySqlDataReader reader;
            MySqlCommand cmd;

            try
            {
                using (conn = new(_connectionString))

                {
                    conn.Open();

                    cmd = new("SELECT * FROM GasCard WHERE CardNumber = '" + cardNum.ToString() + "' AND Deleted=0;", conn);

                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader[0];
                            string cardnumber = (string)reader[1];
                            DateTime expiringdate = (DateTime)reader[2];
                            int? pincode = (int?)((reader[3] is DBNull) ? null : reader[3]);
                            List<FuelType> fuels = new List<FuelType>();
                            string fuelsDB = (string?)((reader[4] is DBNull) ? null : reader[4]);
                            if (fuelsDB != null)
                            {
                                string[] fArrStrs = fuelsDB.Split(",");
                                foreach (string fArrStr in fArrStrs)
                                {
                                    fuels.Add((FuelType)Enum.Parse(typeof(FuelType), fArrStr));
                                }
                            }
                            //Driver? driver = (Driver)reader[5];
                            bool blocked = Convert.ToBoolean(reader[6]);


                            card = null; //new(cardnumber, expiringdate, pincode, blocked, fuels, null);
                        }
                        reader.Close();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DataException("GasCardRepo-GetAllGasCards", ex);
            }

            return card;
        }

        public List<GasCard> GetAllGasCards()
        {
            List<GasCard> cards = new List<GasCard>();
            MySqlConnection conn;
            MySqlDataReader reader;
            MySqlCommand cmd;
            try
            {
                using (conn = new(_connectionString))

                {
                    conn.Open();

                    cmd = new("SELECT * FROM GasCard WHERE Deleted=0;", conn);

                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader[0];
                            string cardnumber = (string)reader[1];
                            DateTime expiringdate = (DateTime)reader[2];
                            int? pincode = (int?)((reader[3] is DBNull) ? null : reader[3]);
                            List<FuelType> fuels = new List<FuelType>();
                            string fuelsDB = (string?)((reader[4] is DBNull)?null:reader[4]);
                            if(fuelsDB!=null)
                            {
                                string[] fArrStrs = fuelsDB.Split(",");
                                foreach (string fArrStr in fArrStrs)
                                {
                                    fuels.Add((FuelType)Enum.Parse(typeof(FuelType), fArrStr));
                                }
                            }
                            //Driver? driver = (Driver)reader[5];
                            bool blocked = Convert.ToBoolean(reader[6]);


                            GasCard gc = null;// new(cardnumber, expiringdate, pincode, blocked, fuels, null);
                            cards.Add(gc);
                        }
                        reader.Close();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DataException("GasCardRepo-GetAllGasCards", ex);
            }
            return cards;
        }

        public List<GasCardInfo> GetGasCardInfos()
        {
            List<GasCardInfo> cardsInfos = new List<GasCardInfo>();
            MySqlConnection conn;
            MySqlDataReader reader;
            MySqlCommand cmd;
            try
            {
                using (conn = new(_connectionString))

                {
                    conn.Open();

                    cmd = new("SELECT * FROM GasCard gc LEFT JOIN Driver d ON gc.DriverID=d.DriverID WHERE gc.Deleted=0;", conn);

                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader[0];
                            string cardnumber = (string)reader[1];
                            DateTime expiringdate = (DateTime)reader[2];
                            int? pincode = (int?)((reader[3] is DBNull) ? null : reader[3]);
                            List<FuelType> fuels = new List<FuelType>();
                            string? fuelsDB = (string?)((reader[4] is DBNull) ? null : reader[4]);
                            if (fuelsDB != null)
                            {
                                string[] fArrStrs = fuelsDB.Split(",");
                                foreach (string fArrStr in fArrStrs)
                                {
                                    fuels.Add((FuelType)Enum.Parse(typeof(FuelType), fArrStr));
                                }
                            }
                            bool blocked = Convert.ToBoolean(reader[6]);

                            GasCard gc = DomainFactory.CreateGasCard(id, cardnumber, expiringdate, pincode, fuels, blocked);
                            Driver d = null;

                            if (reader[8] is not DBNull)
                            {
                                //driver
                                int driverID = (int)reader[8];
                                string fName = (string)reader["FirstName"];
                                string lName = (string)reader["LastName"];
                                string? address = (string?)((reader["Address"] is DBNull) ? null : reader["Address"]);
                                DateTime birthDate = (DateTime)reader["BirthDate"];
                                string natRegNum = (string)reader["NationalRegistrationNumber"];
                                List<DriversLicense> licenseList = new List<DriversLicense>();
                                string licensesDB = (string)reader["DriversLicenses"];
                                string[] lArrStrs = licensesDB.Split(",");
                                foreach (string lArrStr in lArrStrs)
                                {
                                    licenseList.Add((DriversLicense)Enum.Parse(typeof(DriversLicense), lArrStr));
                                }
                                d = DomainFactory.CreateDriver(driverID, lName, fName, natRegNum, licenseList, birthDate, address);
                            }

                            GasCardInfo cardInfo = new(gc, d);
                            cardsInfos.Add(cardInfo);
                        }
                        reader.Close();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DataException("GasCardRepo-GetAllGasCards", ex);
            }
            return cardsInfos;
        }
    }
}
