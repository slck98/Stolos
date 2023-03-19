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

                    cmd = new("SELECT * FROM GasCard WHERE CardNumber = " + cardNum + " AND Deleted=0;", conn);

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


                            card = new(cardnumber, expiringdate, pincode, blocked, fuels, null);
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


                            GasCard gc = new(cardnumber, expiringdate, pincode, blocked, fuels, null);
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
    }
}
