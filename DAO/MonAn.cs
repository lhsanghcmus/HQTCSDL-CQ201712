using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{

    public class MonAn
    {
        public static List<DTO.MonAn> GetThucDon(int maChiNhanh, int offset, int limit)
        {
            List<DTO.MonAn> result = new List<DTO.MonAn>();

            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_GetThucDon", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaChiNhanh", SqlDbType.Int, 100).Value = maChiNhanh;
            cmd.Parameters.Add("@offset", SqlDbType.Int, 100).Value = offset;
            cmd.Parameters.Add("@limit", SqlDbType.Int, 100).Value = limit;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DTO.MonAn monAn = new DTO.MonAn();
                monAn.MaMon = int.Parse(reader["MAMON"].ToString());
                monAn.TenMon = reader["TENMON"].ToString();
                monAn.MaLoai = int.Parse(reader["MALOAI"].ToString());
                monAn.SoLuong = int.Parse(reader["SOLUONG"].ToString());
                monAn.DonGia = double.Parse(reader["DONGIA"].ToString());
                byte[] img = (byte[])(reader["HINHANH"]);
   
                if (img == null)
                {
                    monAn.HinhAnh = null;
                }
                else
                {
                    monAn.HinhAnh = DTO.MonAn.BitmapImageFromBytes(img);
                }
                result.Add(monAn);
            }
            DataProvider.CloseConnection(con);
            return result;
        }
    }
}
