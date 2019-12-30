using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongTinThanhToan
    {
        private DTO.MonAn[] listMonAnDuocChon;
        private string tenDuong;
        private string tenPhuong;
        private string tenQuan;
        private string tenThanhPho;
        private string tenNguoiNhan;
        private string tenNguoiDat;
        private string sdtLienLac;
        private int maThanhVien;
        private int maChiNhanh;
        private int hinhThuc;
        private int loai;
        private string maKhuyenMai;

        public DTO.MonAn[] ListMonAnDuocChon { get => listMonAnDuocChon; set => listMonAnDuocChon = value; }
        public string TenDuong { get => tenDuong; set => tenDuong = value; }
        public string TenPhuong { get => tenPhuong; set => tenPhuong = value; }
        public string TenThanhPho { get => tenThanhPho; set => tenThanhPho = value; }
        public string TenNguoiNhan { get => tenNguoiNhan; set => tenNguoiNhan = value; }
        public string TenNguoiDat { get => tenNguoiDat; set => tenNguoiDat = value; }
        public string SdtLienLac { get => sdtLienLac; set => sdtLienLac = value; }
        public int MaThanhVien { get => maThanhVien; set => maThanhVien = value; }
        public int MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }
        public int HinhThuc { get => hinhThuc; set => hinhThuc = value; }
        public int Loai { get => loai; set => loai = value; }
        public string MaKhuyenMai { get => maKhuyenMai; set => maKhuyenMai = value; }
        public string TenQuan { get => tenQuan; set => tenQuan = value; }

        public ThongTinThanhToan()
        {
            ListMonAnDuocChon = null;
            TenDuong = TenPhuong = TenQuan = TenThanhPho = TenNguoiNhan = TenNguoiDat = SdtLienLac = "";
            MaThanhVien = MaChiNhanh = HinhThuc = Loai = 0;
            MaKhuyenMai = "";
        }
    }
}
