using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class NhanVienQuanLy
    {
        public static DTO.NhanVienQuanLy GetNhanVienQuanLy(string userName, string passWord)
        {
            return DAO.NhanVienQuanLy.GetNhanVienQuanLy(userName, passWord);
        }
    }
}
