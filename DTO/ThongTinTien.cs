using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongTinTien
    {
        private double tongTamTinh;
        private double phiVanChuyen;
        private double giamGia;
        private double tongTien;
        private int maLoi;
        private int maDonCuoiCung;

        public double TongTamTinh { get => tongTamTinh; set => tongTamTinh = value; }
        public double PhiVanChuyen { get => phiVanChuyen; set => phiVanChuyen = value; }
        public double GiamGia { get => giamGia; set => giamGia = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public int MaLoi { get => maLoi; set => maLoi = value; }
        public int MaDonCuoiCung { get => maDonCuoiCung; set => maDonCuoiCung = value; }

        public ThongTinTien()
        {
            TongTamTinh = PhiVanChuyen = GiamGia = TongTamTinh = 0;
            MaLoi = MaDonCuoiCung = 0;
        }
    }
}
