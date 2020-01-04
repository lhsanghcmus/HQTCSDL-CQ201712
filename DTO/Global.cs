using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class Global
    {
        public static int MaChiNhanh = 0;
        public static DTO.ChiNhanh ChiNhanh = null;
        public static int LoaiUser = 0;
        public static Dictionary<string, object> ScreenMapping = new Dictionary<string, object>();
        public static ThanhVien ThanhVien = null;
        public static NhanVien NhanVien = null;
        public static NhanVienQuanLy NhanVienQuanLy = null;
        public static double TongTamTinh = 0;
        public static double PhiVanChuyen = 0;
        public static double GiamGia = 0;
        public static double TongTien= 0;
        public static DTO.MonAn[] DanhSachMonAn = null;
        public static List<int> DonHangDaDat = new List<int>();
        public static List<int> DonHangNhap = new List<int>();

        public static bool fixLostUpdate = false;
        public static bool fixDeadlock = false;

        public static bool fixUnrepeatableRead = false;
        public static bool fixDirtyRead = false;
        public static bool fixPhantom = false;

        public static int typeOfErr = 0;
        public static bool isFixed = false;

    }
}
