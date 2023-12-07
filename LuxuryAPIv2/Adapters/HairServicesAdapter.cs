using System;
using System.Linq;
using LuxuryAPIv2.Data;
using LuxuryAPIv2.Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace LuxuryAPIv2.Adapters
{
    public class HairServicesAdapter
    {
        // Define a list for Hair services
        private static List<HairService> hairServices = new List<HairService>();
        // Define SQL connection 
        private static SqlConnection conn = DataContext.Connection;

        // Properties
        public static List<HairService> HairServices
        {
            get => hairServices;
            set => hairServices = value;
        }

        // Method(s) that direct-interact with server
        public static int GetCurrentId()
        {
            return FetchData().Max(k => k.IdSvc);
        }
        public static List<HairService> FetchData()
        {
            // Define a linked list
            List<HairService> fetchList = new List<HairService>();
            // Open connection
            conn.Open();
            // Build SQL Executor
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM HairServices;";
            // Build SQL Reader
            SqlDataReader reader = cmd.ExecuteReader();
            // Check if data has >= 1 row
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Read fetched data
                    int IdSvc = Convert.ToInt32(reader["IdSvc"]);
                    string Name = Convert.ToString(reader["Name"]);
                    double Price = Convert.ToDouble(reader["Price"]);
                    int IdCate = Convert.ToInt32(reader["IdCate"]);
                    // Add data to linked list 
                    fetchList.Add(new HairService(IdSvc, Name, Price, IdCate));
                }
                // Close the reader & connection
                reader.Close();
                conn.Close();
                // Assign fetched data to ListCate
                HairServices = fetchList;

                // Return data
                return fetchList;
            }

            return null;
        }

        // API Function(s)
        public static HairService[] GetAll()
        {
            HairServices = FetchData();
            if(HairServices != null)
            {
                return HairServices.ToArray();
            }

            return null;
        }
        public static HairService[] GetItem(int IdSvc)
        {
            HairServices = FetchData();
            if (HairServices != null)
            {
                return HairServices.Where(k => k.IdSvc == IdSvc).ToArray();
            }

            return null;
        }
    }
}