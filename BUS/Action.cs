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
    }
}
