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

        public string TenChiNhanh { get => tenChiNhanh; set => tenChiNhanh = value; }
        public int MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }

        public ChiNhanh()
        {
            maChiNhanh = 0;
            tenChiNhanh = "";
        }
    }
}
