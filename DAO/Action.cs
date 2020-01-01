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
                DTO.Global.TongTamTinh = double.Parse(cmd.Parameters["@TongTamTinh"].Value.ToString());
                DTO.Global.PhiVanChuyen = double.Parse(cmd.Parameters["@PhiVanChuyen"].Value.ToString());
                DTO.Global.GiamGia = double.Parse(cmd.Parameters["@GiamGia"].Value.ToString());
                DTO.Global.TongTien = double.Parse(cmd.Parameters["@TongTien"].Value.ToString());
                DataProvider.CloseConnection(con);

            } catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                return MaLoi;
            }
            DataProvider.CloseConnection(con);
            return MaLoi;
        }

        public static DTO.ThongTinDonHang[] GetDanhSachDonHang(int Code)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd;
            if (DTO.Global.ThanhVien == null)
            {
                cmd = new SqlCommand("sp_DSDH_NV", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaChiNhanh", Code);
            } else
            {
                cmd = new SqlCommand("sp_DSDH_TV", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaThanhVien", Code);
            }
            

            SqlDataReader reader = cmd.ExecuteReader();
            List<DTO.ThongTinDonHang> result = new List<DTO.ThongTinDonHang>();
            while (reader.Read())
            {
                DTO.ThongTinDonHang tmp = new DTO.ThongTinDonHang();
                tmp.MaDonHang = int.Parse(reader["MADONHANG"].ToString());
                int TrangThai = int.Parse(reader["TRANGTHAI"].ToString());
                switch (TrangThai)
                {
                    case 1:
                        tmp.TrangThai = "Tiếp nhận";
                        tmp.ColorStatus = "Green";
                        break;
                    case 2:
                        tmp.TrangThai = "Đang chuẩn bị";
                        tmp.ColorStatus = "Orange";
                        break;
                    case 3:
                        tmp.TrangThai = "Đang giao";
                        tmp.ColorStatus = "Red";
                        break;
                    case 4:
                        tmp.TrangThai = "Hoàn tất";
                        tmp.ColorStatus = "Green";
                        break;
                    case 0:
                        tmp.TrangThai = "Đơn nháp";
                        tmp.ColorStatus = "Orange";
                        break;
                    default:
                        tmp.TrangThai = "Hủy";
                        tmp.ColorStatus = "Red";
                        break;
                }
                int Loai = int.Parse(reader["LOAI"].ToString());
                switch (Loai)
                {
                    case 1:
                        tmp.Loai = "Khách vãng lai";
                        break;
                    case 2:
                        tmp.Loai = "Thành viên";
                        break;
                }
                int HinhThuc = int.Parse(reader["HINHTHUC"].ToString());
                switch (HinhThuc)
                {
                    case 1:
                        tmp.HinhThuc = "Online";
                        break;
                    case 2:
                        tmp.HinhThuc = "Trực tiếp";
                        break;
                    case 3:
                        tmp.HinhThuc = "Điện thoại";
                        break;
       
                }
                tmp.TenNguoiDat = reader["TENNGUOIDAT"].ToString();
                tmp.TenNguoiNhan = reader["TENNGUOINHAN"].ToString();
                tmp.SdtLienLac = reader["SDTLIENLAC"].ToString();
                tmp.DiaChiDat = reader["DIACHIDAT"].ToString();
                tmp.DiaChiNhan = reader["DIACHINHAN"].ToString();
                if (reader.IsDBNull(12))
                {
                    tmp.TongTien = DTO.Global.TongTien;
                } else
                {
                    tmp.TongTien = double.Parse(reader[12].ToString());
                }
                if (reader.IsDBNull(11))
                {
                    tmp.GiamGia = DTO.Global.GiamGia;
                }
                else
                {
                    tmp.GiamGia = double.Parse(reader[11].ToString());
                }
                if (reader.IsDBNull(10))
                {
                    tmp.PhiVanChuyen = DTO.Global.PhiVanChuyen;
                }
                else
                {
                    tmp.PhiVanChuyen = double.Parse(reader[10].ToString());
                }
                if (reader.IsDBNull(9))
                {
                    tmp.TongTamTinh = DTO.Global.TongTamTinh;
                }
                else
                {
                    tmp.TongTamTinh = double.Parse(reader[9].ToString());
                }
                result.Add(tmp);
            }
            return result.ToArray();
        }

        public static int HuyDonHang(int MaDonHang)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_HUYDONHANG_KH", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaDonHang", MaDonHang);
            cmd.Parameters.AddWithValue("@MaLoi", 0);
            cmd.Parameters["@MaLoi"].Direction = ParameterDirection.Output;
            int MaLoi = -1;
            try
            {
                cmd.ExecuteNonQuery(); 
                MaLoi = int.Parse(cmd.Parameters["@MaLoi"].Value.ToString());
                DataProvider.CloseConnection(con);
                return MaLoi;
            } catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                return MaLoi;
            }

        }



    }
}
