﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    //nhi xinh dep va huyen xinh dep hihi

    public class DataProvider
    {
        public static SqlConnection GetConnection()
        {
            string[] arrConectionString = new string[3];
            arrConectionString[0] = @"Data Source=GHN-TECH-LP0126;Initial Catalog=HuongVietRestaurant;Integrated Security=True";
            arrConectionString[1] = @"Data Source=HUYENN;Initial Catalog=HuongVietRestaurant;Integrated Security=True";
            arrConectionString[2] = @"Data Source=DESKTOP-DPU2LFR\SQLEXPRESS;Initial Catalog=HuongVietRestaurant;Integrated Security=True";
            string connectionString = arrConectionString[0];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }
        public static void CloseConnection(SqlConnection con)
        {
            con.Close();
        }
    }
}
