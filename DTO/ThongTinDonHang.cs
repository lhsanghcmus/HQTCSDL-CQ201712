using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongTinDonHang
    {
        private int maDonHang;
        private string diaChiDat;
        private string diaChiNhan;
        private string tenNguoiDat;
        private string tenNguoiNhan;
        private string sdtLienLac;
        private double tongTien;
        private string trangThai;
        private string loai;
        private string hinhThuc;
        private string colorStatus;
        private double tongTamTinh;
        private double phiVanChuyen;
        private double giamGia;
        public int MaDonHang { get => maDonHang; set => maDonHang = value; }
        public string DiaChiDat { get => diaChiDat; set => diaChiDat = value; }
        public string DiaChiNhan { get => diaChiNhan; set => diaChiNhan = value; }
        public string TenNguoiDat { get => tenNguoiDat; set => tenNguoiDat = value; }
        public string TenNguoiNhan { get => tenNguoiNhan; set => tenNguoiNhan = value; }
        public string SdtLienLac { get => sdtLienLac; set => sdtLienLac = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string Loai { get => loai; set => loai = value; }
        public string HinhThuc { get => hinhThuc; set => hinhThuc = value; }
        public string ColorStatus { get => colorStatus; set => colorStatus = value; }
        public double TongTamTinh { get => tongTamTinh; set => tongTamTinh = value; }
        public double PhiVanChuyen { get => phiVanChuyen; set => phiVanChuyen = value; }
        public double GiamGia { get => giamGia; set => giamGia = value; }

        public ThongTinDonHang()
        {
            MaDonHang = 0;
            DiaChiDat = diaChiNhan = TenNguoiDat = tenNguoiNhan = SdtLienLac = TrangThai = "";
            TongTien = 0;
            ColorStatus = "";
        }

    }
}
