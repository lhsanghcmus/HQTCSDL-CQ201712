using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiNhanh
    {
        private string tenChiNhanh;
        private int maChiNhanh;
        private string tenDuong;
        private string tenPhuong;
        private string tenQuan;
        private string tenThanhPho;
        public string TenChiNhanh { get => tenChiNhanh; set => tenChiNhanh = value; }
        public int MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }
        public string TenDuong { get => tenDuong; set => tenDuong = value; }
        public string TenPhuong { get => tenPhuong; set => tenPhuong = value; }
        public string TenQuan { get => tenQuan; set => tenQuan = value; }
        public string TenThanhPho { get => tenThanhPho; set => tenThanhPho = value; }

        public ChiNhanh()
        {
            maChiNhanh = 0;
            tenChiNhanh = "";
            
        }
    }
}
