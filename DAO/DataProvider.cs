using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{

    public class DataProvider
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=GHN-TECH-LP0126;Initial Catalog=HuongVietRestaurant;Integrated Security=True";
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
