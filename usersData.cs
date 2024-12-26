﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace hotelManagementSystem
{
    internal class usersData
    {
        private string conn = @"Data Source=DESKTOP-I7PF7E5;Initial Catalog=hotel;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public int No { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }

        public string Role { set; get; }
        public string Status { set; get; }
        public string DateReg { set; get; }

        public List<usersData> listUsersData()
        {
            List<usersData> listData = new List<usersData>();
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT * FROM users";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        usersData uData = new usersData();

                        uData.No = (int)reader["id"];
                        uData.Username = reader["username"].ToString();
                        uData.Password = reader["password"].ToString();
                        uData.Role = reader["role"].ToString();
                        uData.Status = reader["status"].ToString();
                        uData.DateReg = reader["date_register"].ToString();

                        listData.Add(uData);
                    }
                }
            }
            return listData;
        }
    }
}