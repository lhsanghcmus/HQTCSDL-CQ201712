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
    public class ThanhVien
    {
        public static DTO.ThanhVien GetThanhVien(string userName, string passWord)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_GetThanhVien", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = userName;
            cmd.Parameters.Add("@PassWord", SqlDbType.NVarChar, 500).Value = passWord;

            SqlDataReader reader = cmd.ExecuteReader();
            DTO.ThanhVien result = null;

            while (reader.Read())
            {
                result = new DTO.ThanhVien();
                result.MaThanhVien = int.Parse(reader["MATHANHVIEN"].ToString());
                result.HoTen = reader["HOTEN"].ToString();
                result.Cmnd = reader["CMND"].ToString();
                result.NgaySinh = reader["NGAYSINH"].ToString();
                result.MaChiNhanh = int.Parse(reader["MACHINHANH"].ToString());
                result.Sdt = reader["SDT"].ToString();
                result.Email = reader["EMAIL"].ToString();
                try
                {
                   result.DiemTichLuy = double.Parse(reader["DIEMTICHLUY"].ToString());
                }
                catch
                {
                    result.DiemTichLuy = 0;
                }
                result.MatKhau = reader["MATKHAU"].ToString();
                if (reader["ISDELETED"].ToString().Equals("true"))
                {
                    result.IsDeleted = true;
                } else
                {
                    result.IsDeleted = false;
                }
                break;
            }
            DataProvider.CloseConnection(con);
            return result;
        }
    }
}
