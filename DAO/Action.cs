﻿using System;
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
        public static string DatMon(DTO.ThongTinTien info)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd;
            if (DTO.Global.fixLostUpdate == false)
            {
                cmd = new SqlCommand("SP_DATMONchuaFixLostUpdate", con);
            } else
            {
                if (DTO.Global.fixDeadlock == false)
                {
                    cmd = new SqlCommand("SP_DATMON_lostUpdate_ChuaFixDeadLock", con);
                } else
                {
                    cmd = new SqlCommand("SP_DATMONlostUpdate_DaFixDeadLock", con);
                }
            }


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
                if (MaLoi == 0)
                {
                    return "";
                }
                if (MaLoi == 2)
                {
                    return "Số lượng còn lại của khuyến mãi không đủ";
                }
                if (MaLoi == 1)
                {
                    return "Số lượng còn lại của món ăn không đủ";
                }

            } catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                return e.Message;
            }
            return "";
         //   DataProvider.CloseConnection(con);
           
        }

        public static DTO.ThongTinDonHang[] GetDanhSachDonHang(int Code)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd;
            if (DTO.Global.ThanhVien == null)
            {
                if (DTO.Global.fixPhantom == false)
                {
                    cmd = new SqlCommand("sp_DSDH_NV_chuaFixPhantom", con);
                } else
                {
                    cmd = new SqlCommand("sp_DSDH_NV_daFixPhantom", con);
                }
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
            SqlCommand cmd;
            if (DTO.Global.fixLostUpdate == false)
            {
                cmd = new SqlCommand("sp_HUYDONHANG_KH_chuaFixLostUpdate", con);
            } else
            {
                if (DTO.Global.fixDeadlock == false)
                {
                    cmd = new SqlCommand("sp_HUYDONHANG_KH_lostUpdate_ChuaFixDeadLock", con);
                } else
                {
                    cmd = new SqlCommand("sp_HUYDONHANG_KH_lostUpdate_daFixDeadLock", con);
                }
            }
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

        public static int CapNhatTrangThaiDonhang(int MaDonHang, int TrangThaiMoi)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd;
            if (DTO.Global.fixLostUpdate == false)
            {
                cmd = new SqlCommand("SP_CAPNHATTRANGTHAIDON_chuaFixLostUpdate", con);
            } else
            {
                if (DTO.Global.fixDeadlock == false)
                {
                    cmd = new SqlCommand("SP_CAPNHATTRANGTHAIDON_lostUpdate_ChuaFixDeadLock", con);
                } else
                {
                    cmd = new SqlCommand("SP_CAPNHATTRANGTHAIDON_lostUpdate_daFixDeadLock", con);
                }
            }
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaDonHang", MaDonHang);
            cmd.Parameters.AddWithValue("@TrangThaiMoi", TrangThaiMoi);
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

        public static string CapNhatMonAn(int MaMon, int MaChiNhanh, double DonGia, string TenMon, int SoLuongMoi)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd;
            if (DTO.Global.fixLostUpdate == false)
            {
                cmd = new SqlCommand("sp_UpdateMonAnchuaFixLostUpdate", con);
            }
            else
            {
                if (DTO.Global.fixDeadlock == false)
                {
                    cmd = new SqlCommand("sp_UpdateMonAnlostUpdate_ChuaFixDeadLock", con);
                } else
                {
                    cmd = new SqlCommand("sp_UpdateMonAnlostUpdate_DaFixDeadLock", con);
                }
            }
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaMon", MaMon);
            cmd.Parameters.AddWithValue("@MaChiNhanh", MaChiNhanh);
            cmd.Parameters.AddWithValue("@DonGia", DonGia);
            cmd.Parameters.AddWithValue("@TenMon", TenMon);
            cmd.Parameters.AddWithValue("@SoLuongMoi", SoLuongMoi);
            cmd.Parameters.AddWithValue("@MaLoi", 0);
            cmd.Parameters["@MaLoi"].Direction = ParameterDirection.Output;
            int MaLoi = -1;
            try
            {
                cmd.ExecuteNonQuery();
                MaLoi = int.Parse(cmd.Parameters["@MaLoi"].Value.ToString());
                DataProvider.CloseConnection(con);
                if (MaLoi == 0)
                {
                    return "";
                }
                if (MaLoi == 1)
                {
                    return "Số lượng món ăn còn lại không đủ";
                }
            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                return e.Message;
            }
            if (MaLoi == 0)
            {
                return "";
            }
            if (MaLoi == 1)
            {
                return "Số lượng món ăn còn lại không đủ";
            }
            return "";
        }

        public static DTO.MonAn[] LayMonAnChuaCoTrongChiNhanh(int MaChiNhanh)
        {
            List<DTO.MonAn> result = new List<DTO.MonAn>();
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_LayMonChuaCoTrongChiNhanh", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaChiNhanh", MaChiNhanh);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DTO.MonAn monAn = new DTO.MonAn();
                monAn.MaMon = int.Parse(reader["MAMON"].ToString());
                monAn.TenMon = reader["TENMON"].ToString();
                monAn.MaLoai = int.Parse(reader["MALOAI"].ToString());
                monAn.DonGia = double.Parse(reader["DONGIA"].ToString());
                monAn.HinhAnh = null;
                result.Add(monAn);
            }
            DataProvider.CloseConnection(con);
            return result.ToArray();
        }

        public static int ThemMonVaoChiNhanh(int MaMon, int MaChiNhanh, int SoLuong)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_ThemMonVaoChiNhanh", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaChiNhanh", MaChiNhanh);
            cmd.Parameters.AddWithValue("@MaMon", MaMon);
            cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            cmd.Parameters.AddWithValue("@MaLoi", 0);
            cmd.Parameters["@MaLoi"].Direction = ParameterDirection.Output;
            int MaLoi = -1;
            try
            {
                cmd.ExecuteNonQuery();
                MaLoi = int.Parse(cmd.Parameters["@MaLoi"].Value.ToString());
                DataProvider.CloseConnection(con);
                return MaLoi;
            }catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                return MaLoi;
            }
        }

        public static int XoaMonKhoiChiNhanh(int MaMon, int MaChiNhanh)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_XoaMonAnKhoiChiNhanh", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaChiNhanh", MaChiNhanh);
            cmd.Parameters.AddWithValue("@MaMon", MaMon);
            cmd.Parameters.AddWithValue("@MaLoi", 0);
            cmd.Parameters["@MaLoi"].Direction = ParameterDirection.Output;
            int MaLoi = -1;
            try
            {
                cmd.ExecuteNonQuery();
                MaLoi = int.Parse(cmd.Parameters["@MaLoi"].Value.ToString());
                DataProvider.CloseConnection(con);
                return MaLoi;
            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                return MaLoi;
            }
        }

    }
}
