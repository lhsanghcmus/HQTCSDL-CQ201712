using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class ThanhVien
    {
        public static DTO.ThanhVien GetThanhVien(string userName, string passWord)
        {
            return DAO.ThanhVien.GetThanhVien(userName, passWord);
        }
    }
}
