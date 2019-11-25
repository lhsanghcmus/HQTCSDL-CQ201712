using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThanhVien
    {
        private int maThanhVien;
        private string hoTen;
        private string cmnd;
        private string ngaySinh;
        private int maChiNhanh;
        private string sdt;
        private string email;
        private double diemTichLuy;
        private string matKhau;
        private bool isDeleted;

        public int MaThanhVien { get => maThanhVien; set => maThanhVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public double DiemTichLuy { get => diemTichLuy; set => diemTichLuy = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }

        public ThanhVien()
        {
            HoTen = Cmnd = NgaySinh = Sdt = Email = MatKhau = "";
            MaChiNhanh = 0;
            DiemTichLuy = 0;
            MaThanhVien = 0;
            IsDeleted = false;
        }

    }
}
