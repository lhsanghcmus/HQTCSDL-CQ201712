using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Action
    {
        public static int DatMon(DTO.ThongTinTien info)
        {
            return DAO.Action.DatMon(info);
        }
        public static DTO.ThongTinDonHang[] GetDanhSachDonHang(int Code)
        {
            return DAO.Action.GetDanhSachDonHang(Code);
        }
        public static int HuyDonHang(int MaDonHang)
        {
            return DAO.Action.HuyDonHang(MaDonHang);
        }
    }
}
