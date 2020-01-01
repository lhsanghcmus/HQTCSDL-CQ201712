using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ChiNhanh
    {
        public static List<DTO.ChiNhanh> LoadDSChiNhanh()
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_LoadDSChiNhanh", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            List<DTO.ChiNhanh> result = new List<DTO.ChiNhanh>();

            while (reader.Read())
            {
                DTO.ChiNhanh chiNhanh = new DTO.ChiNhanh();
                chiNhanh.MaChiNhanh = int.Parse((reader["MaChiNhanh"].ToString()));
                chiNhanh.TenChiNhanh = reader["TenChiNhanh"].ToString();
                chiNhanh.TenDuong = reader["TenDuong"].ToString();
                chiNhanh.TenPhuong = reader["TenPhuong"].ToString();
                chiNhanh.TenQuan = reader["TenQuan"].ToString();
                chiNhanh.TenThanhPho = reader["TenThanhPho"].ToString();
                result.Add(chiNhanh);
            }
            DataProvider.CloseConnection(con);
            return result;
        }
    }
}
