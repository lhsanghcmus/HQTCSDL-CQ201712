using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Action
    {
        public static string DatMon(DTO.ThongTinTien info)
        {
            return DAO.Action.DatMon(info);
        }
        public static DTO.ThongTinDonHang[] GetDanhSachDonHang(int Code)
        {
            return DAO.Action.GetDanhSachDonHang(Code);
        }
        public static int HuyDonHang(int MaDonHang)
        {
            return DAO.Action.HuyDonHang(MaDonHang);
        }
        public static int CapNhatTrangThaiDonhang(int MaDonHang, int TrangThaiMoi)
        {
            return DAO.Action.CapNhatTrangThaiDonhang(MaDonHang, TrangThaiMoi);
        }
        public static string CapNhatMonAn(int MaMon, int MaChiNhanh, double DonGia, string TenMon, int SoLuongMoi)
        {
            return DAO.Action.CapNhatMonAn(MaMon, MaChiNhanh, DonGia, TenMon, SoLuongMoi);
        }
        public static DTO.MonAn[] LayMonAnChuaCoTrongChiNhanh(int MaChiNhanh)
        {
            return DAO.Action.LayMonAnChuaCoTrongChiNhanh(MaChiNhanh);
        }
        public static int ThemMonVaoChiNhanh(int MaMon, int MaChiNhanh, int SoLuong)
        {
            return DAO.Action.ThemMonVaoChiNhanh(MaMon, MaChiNhanh, SoLuong);
        }
        public static int XoaMonKhoiChiNhanh(int MaMon, int MaChiNhanh)
        {
            return DAO.Action.XoaMonKhoiChiNhanh(MaMon, MaChiNhanh);
        }
    }
}
