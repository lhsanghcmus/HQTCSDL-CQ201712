using System;
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
            string connectionString = @"Data Source=DESKTOP-DPU2LFR\SQLEXPRESS;Initial Catalog=HuongVietRestaurant;Integrated Security=True";
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
