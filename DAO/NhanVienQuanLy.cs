using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class NhanVienQuanLy
    {
        public static DTO.NhanVienQuanLy GetNhanVienQuanLy(string userName, string passWord)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_GetNhanVienQuanLy", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = userName;
            cmd.Parameters.Add("@PassWord", SqlDbType.NVarChar, 500).Value = passWord;

            SqlDataReader reader = cmd.ExecuteReader();
            DTO.NhanVienQuanLy result = null;

            while (reader.Read())
            {
                result = new DTO.NhanVienQuanLy();
                result.MaNhanVien = int.Parse(reader["MANHANVIEN"].ToString());
                result.HoTen = reader["HOTEN"].ToString();
                result.Cmnd = reader["CMND"].ToString();
                result.Sdt = reader["SDT"].ToString();
                result.Email = reader["EMAIL"].ToString();
                result.MatKhau = reader["MATKHAU"].ToString();
               
            }
            DataProvider.CloseConnection(con);
            return result;
        }
    }
}
