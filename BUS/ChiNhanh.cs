﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class ChiNhanh
    {
        public static List<DTO.ChiNhanh> LoadDSChiNhanh()
        {
            return DAO.ChiNhanh.LoadDSChiNhanh();
        }
    }
}
