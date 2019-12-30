using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThongTinThanhToan
    {
        public static DTO.ThongTinTien GetThongTinTien(DTO.ThongTinThanhToan info)
        {
            return DAO.ThongTinThanhToan.GetThongTinTien(info);
        }
    }
}
