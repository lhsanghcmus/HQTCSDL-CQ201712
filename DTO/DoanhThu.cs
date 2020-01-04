using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoanhThu
    {
        private int maChiNhanh;
        private string tenChiNhanh;
        private double luongDoanhThu;
        private double tongDoanhThu;
        public int MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }
        public string TenChiNhanh { get => tenChiNhanh; set => tenChiNhanh = value; }
        public double LuongDoanhThu { get => luongDoanhThu; set => luongDoanhThu = value; }
        public double TongDoanhThu { get => tongDoanhThu; set => tongDoanhThu = value; }

        public DoanhThu()
        {
            MaChiNhanh = 0;
            LuongDoanhThu = 0;
            TenChiNhanh = "";
        }

    }
}
