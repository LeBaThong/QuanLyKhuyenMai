using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class HINHTHUCGIAMGIA_BLL
    {
        public static List<HINHTHUCGIAMGIA> LoadHinhThucGiamGia()
        {
            return HINHTHUCGIAMGIA_DAL.LoadHinhThucGiamGia();
        }
    }
}
