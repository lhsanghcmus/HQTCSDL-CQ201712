using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Action
    {
        public static int DatMon(DTO.ThongTinTien info)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("SP_DATMON", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaDonHang", info.MaDonCuoiCung);
            cmd.Parameters.AddWithValue("@HinhThucThanhToan", 1);
            cmd.Parameters.AddWithValue("@TongTamTinh", info.TongTamTinh);
            cmd.Parameters.AddWithValue("@PhiVanChuyen", info.PhiVanChuyen);
            cmd.Parameters.AddWithValue("@GiamGia", info.GiamGia);
            cmd.Parameters.AddWithValue("@TongTien", info.TongTien);

            cmd.Parameters.AddWithValue("@MaLoi", 0);
            cmd.Parameters["@MaLoi"].Direction = ParameterDirection.Output;

            int MaLoi = -1;
            try
            {
                cmd.ExecuteNonQuery();
                MaLoi = int.Parse(cmd.Parameters["@MaLoi"].Value.ToString());
                DataProvider.CloseConnection(con);

            } catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                return MaLoi;
            }
            DataProvider.CloseConnection(con);
            return MaLoi;
        }
    }
}
