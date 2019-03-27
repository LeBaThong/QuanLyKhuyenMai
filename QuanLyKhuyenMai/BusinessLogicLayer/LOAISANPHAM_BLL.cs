using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class LOAISANPHAM_BLL
    {
        public static List<LOAISANPHAM> LoadLoaiSanPham()
        {
            return LOAISANPHAM_DAL.LoadLoaiSanPham();
        }
    }
}
