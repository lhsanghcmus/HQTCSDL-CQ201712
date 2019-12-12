using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class NhanVien
    {
        public static DTO.NhanVien GetNhanVien(string userName, string passWord)
        {
            return DAO.NhanVien.GetNhanVien(userName, passWord);
        }
    }
}
