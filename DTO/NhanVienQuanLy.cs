using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienQuanLy
    {
        private int maNhanVien;
        private string hoTen;
        private string cmnd;
        private string sdt;
        private string email;
        private string matKhau;
        
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }

        public string MatKhau { get => matKhau; set => matKhau = value; }
        

        public NhanVienQuanLy()
        {
            HoTen = Cmnd = Sdt = Email = MatKhau =  "";
            MaNhanVien = 0;

        }

    }
}
